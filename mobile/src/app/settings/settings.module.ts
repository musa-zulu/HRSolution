import { IonicModule } from '@ionic/angular';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SettingsPage } from './settings.page';
import { ExploreContainerComponentModule } from '../explore-container/explore-container.module';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,  
    ReactiveFormsModule,
    ExploreContainerComponentModule,
    RouterModule.forChild([{ path: '', component: SettingsPage }])
  ],
  declarations: [SettingsPage]
})
export class SettingsPageModule {}
