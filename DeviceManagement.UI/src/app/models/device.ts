export interface Device {
  id: number;
  name: string;
  manufacturer: string;
  type: string;
  operatingSystem: string;
  osVersion: string;
  processor: string;
  ramAmount: string;
  description?: string;
  assignedToUserId?: string;
  assignedToUser?: AppUser;
}

export interface AppUser {
  id: string;
  email: string;
  name: string;
}
