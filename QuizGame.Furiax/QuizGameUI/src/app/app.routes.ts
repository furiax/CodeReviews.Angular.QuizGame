import { Routes } from '@angular/router';
import { MainmenuComponent } from './mainmenu/mainmenu.component';
import { ManagequizComponent } from './managequiz/managequiz.component';


export const routes: Routes = [
    {path: '', component: MainmenuComponent,title: 'QuizGame'},
    {path: 'managequiz', component: ManagequizComponent}
];
