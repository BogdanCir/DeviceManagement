import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Device } from '../models/device';
import { DeviceService } from '../services/device';

@Component({
  selector: 'app-device-list',
  imports: [RouterLink],
  templateUrl: './device-list.html',
  styleUrl: './device-list.css',
})
export class DeviceList implements OnInit {
  devices: Device[] = [];

  constructor(private deviceService: DeviceService) {}

  ngOnInit(): void {
    this.loadDevices();
  }

  loadDevices(): void {
    this.deviceService.getAll().subscribe({
      next: (data) => (this.devices = data),
      error: (err) => console.error('Failed to load devices', err),
    });
  }

  deleteDevice(id: number): void {
    if (confirm('Are you sure you want to delete this device?')) {
      this.deviceService.delete(id).subscribe({
        next: () => this.loadDevices(),
        error: (err) => console.error('Failed to delete device', err),
      });
    }
  }
}
