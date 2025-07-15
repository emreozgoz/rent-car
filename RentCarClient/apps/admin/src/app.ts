import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  imports: [RouterModule],
  selector: 'app-root',
  templateUrl: '<router-outlet>',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class App {}
