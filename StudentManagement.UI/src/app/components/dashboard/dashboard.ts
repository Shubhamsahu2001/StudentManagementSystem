import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {
sidebarOpen = true;

toggleSidebar(): void {
  this.sidebarOpen = !this.sidebarOpen;

  const sidebar = document.getElementById('sidebar-wrapper');

  if (sidebar) {
    sidebar.classList.toggle('d-none');
  }
}
}