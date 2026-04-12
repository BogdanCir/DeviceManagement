import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Device } from '../models/device';
import { DeviceService } from '../services/device';

@Component({
  selector: 'app-device-form',
  imports: [FormsModule],
  templateUrl: './device-form.html',
  styleUrl: './device-form.css',
})
export class DeviceForm implements OnInit {
  device: Device = {
    id: 0,
    name: '',
    manufacturer: '',
    type: '',
    operatingSystem: '',
    osVersion: '',
    processor: '',
    ramAmount: '',
    description: '',
  };

  isEditMode = signal(false);
  errorMessage = signal('');

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private deviceService: DeviceService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode.set(true);
      this.deviceService.getById(Number(id)).subscribe({
        next: (data) => (this.device = data),
        error: () => this.errorMessage.set('Device not found.'),
      });
    }
  }

  onSubmit(): void {
    this.errorMessage.set('');

    if (this.isEditMode()) {
      this.deviceService.update(this.device.id, this.device).subscribe({
        next: () => this.router.navigate(['/devices', this.device.id]),
        error: () => this.errorMessage.set('Failed to update device.'),
      });
    } else {
      // Check if a device with the same name already exists
      this.deviceService.getAll().subscribe({
        next: (devices) => {
          const exists = devices.some(
            (d) => d.name.toLowerCase() === this.device.name.toLowerCase()
          );
          if (exists) {
            this.errorMessage.set('A device with this name already exists.');
            return;
          }
          this.deviceService.create(this.device).subscribe({
            next: (created) => this.router.navigate(['/devices', created.id]),
            error: () => this.errorMessage.set('Failed to create device.'),
          });
        },
        error: () => this.errorMessage.set('Failed to check existing devices.'),
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/devices']);
  }
}
