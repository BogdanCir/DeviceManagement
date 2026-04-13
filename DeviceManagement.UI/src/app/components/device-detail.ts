import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Device } from '../models/device';
import { DeviceService } from '../services/device';
import { AuthService } from '../services/auth';

@Component({
  selector: 'app-device-detail',
  imports: [RouterLink],
  templateUrl: './device-detail.html',
  styleUrl: './device-detail.css',
})
export class DeviceDetail implements OnInit {
  device = signal<Device | null>(null);
  message = signal('');

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private deviceService: DeviceService,
    public authService: AuthService
  ) {}

  ngOnInit(): void {
    this.loadDevice();
  }

  loadDevice(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.deviceService.getById(id).subscribe({
      next: (data) => this.device.set(data),
      error: (err) => console.error('Failed to load device', err),
    });
  }

  assignToMe(): void {
    this.message.set('');
    this.deviceService.assign(this.device()!.id).subscribe({
      next: () => this.loadDevice(),
      error: (err) => this.message.set(err.error?.message || 'Failed to assign device.'),
    });
  }

  unassignFromMe(): void {
    this.message.set('');
    this.deviceService.unassign(this.device()!.id).subscribe({
      next: () => this.loadDevice(),
      error: (err) => this.message.set(err.error?.message || 'Failed to unassign device.'),
    });
  }

  deleteDevice(): void {
    if (confirm('Are you sure you want to delete this device?')) {
      this.deviceService.delete(this.device()!.id).subscribe({
        next: () => this.router.navigate(['/devices']),
        error: (err) => console.error('Failed to delete device', err),
      });
    }
  }
}
