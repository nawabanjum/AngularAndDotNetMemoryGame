import { Component, OnInit } from '@angular/core';
import { CardsLookup } from 'src/app/constants/cards.lookup';
import { CardListInterface } from 'src/app/interfaces/card';

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.scss']
})
export class GameBoardComponent implements OnInit {
  cardsLookup: Array<CardListInterface> = CardsLookup;
  isGameFinished = false;

  constructor() {
    this.startNewGame();
  }
  ngOnInit(): void {
  }
  startNewGame() {
    // Initialize the cards array and other necessary variables
    this.isGameFinished = false;
    // Shuffle the cards (you can implement a shuffle function)
    // Assign the cards to the board
  }

  onCardClick(card: any) {
    console.log(card)
    if (card && card.isFlipped) {
      const foundCard = this.cardsLookup[0].cards?.find((e: any) => { return e == card });

      if (foundCard) {
        foundCard.isMatched = true;
      }
    }

    // Handle the card click logic (flipping, matching, scoring, etc.)
    // Check if the game is finished
    // Update player points and switch turns
  }

}
