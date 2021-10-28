import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { MaterialModule } from './material.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'

const sharedModules: any[] = [
  CommonModule,
  MaterialModule,
  ReactiveFormsModule,
  FormsModule,
]
@NgModule({
  declarations: [],
  imports: sharedModules,
  exports: sharedModules,
})
export class SharedModule {}
