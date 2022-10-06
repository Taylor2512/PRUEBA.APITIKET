import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  template: `
    <div class="app">
      <counter></counter>
    </div>
  `
})
export class AppComponent {
  title = 'app';
}
