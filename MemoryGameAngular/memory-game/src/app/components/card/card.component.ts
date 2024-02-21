import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Card } from 'src/app/interfaces/card';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input() cardValue: Card = {
    id: 0,
    content: '',
    isFlipped: false,
    isMatched: false,
    imageUrl: ''
  };
  @Input() isFlipped: boolean = false;
  @Input() isMatched: boolean = false;
  @Output() cardClicked = new EventEmitter<Card>();
  constructor() { }

  ngOnInit(): void {
  }

  flipCard(cardValue:Card) {
    if(this.isFlipped && !this.isMatched){
      cardValue.isFlipped = false;
    }
    if (!this.isFlipped && !this.isMatched) {
      cardValue.isFlipped = true;
    }
    this.cardClicked.emit(cardValue);
  }

}
