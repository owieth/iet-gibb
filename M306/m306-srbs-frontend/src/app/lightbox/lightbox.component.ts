import { Component, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-lightbox',
  templateUrl: './lightbox.component.html',
  styleUrls: ['./lightbox.component.scss']
})

export class LightboxComponent {

  private open = false;

  @Input()
  get isOpen() {
    return this.open;
  }

  set isOpen(val) {
    this.open = val;
    this.toggleScrollbar();
    this.isOpenChange.emit(this.open);
  }

  @Output() isOpenChange = new EventEmitter();

  constructor(private renderer: Renderer2) {
  }

  toggleScrollbar() {
    if (this.open) {
      this.renderer.addClass(document.body, 'lightbox-open');
      return;
    }
    this.renderer.removeClass(document.body, 'lightbox-open');
  }

  close() {
    this.isOpen = false;
  }

  @HostListener('document:keydown.escape', [])
  onKeydownHandler() {
    this.close();
  }
  
}