import { Routes } from '@angular/router';
import { MainmenuComponent } from './mainmenu/mainmenu.component';
import { NewquizComponent } from './newquiz/newquiz.component';

export const routes: Routes = [
    {path: '', component: MainmenuComponent,title: 'QuizGame'},
    {path: 'newquiz', component: NewquizComponent}
];
