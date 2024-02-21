using MemoryGame.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Services
{
    public class MemoryGameService
    {
        private readonly Random _random = new Random();
        private GameState _gameState;

        public MemoryGameService()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            // Initialize the game state with shuffled cards, scores, and starting player
            var allCards = Enumerable.Range(1, 10).SelectMany(i => new List<Card> { new Card { Id = i * 2 - 1, Content = $"Card {i * 2 - 1}" }, new Card { Id = i * 2, Content = $"Card {i * 2}" } }).ToList();
            var shuffledCards = allCards.OrderBy(c => Guid.NewGuid()).ToList();

            _gameState = new GameState
            {
                Cards = shuffledCards,
                Player1Score = 0,
                Player2Score = 0,
                CurrentPlayer = new Random().Next(1, 3)
            };
        }

        public GameState GetCurrentGameState()
        {
            return _gameState;
        }

        public void HandlePlayerTurn(int playerId, int card1Position, int card2Position)
        {
            if (playerId != _gameState.CurrentPlayer)
            {
                // It's not the player's turn
                throw new InvalidOperationException("It's not your turn.");
            }

            var card1 = GetCard(card1Position);
            var card2 = GetCard(card2Position);

            if (card1 == null || card2 == null || card1.IsFlipped || card2.IsFlipped)
            {
                // Invalid card positions or one of the cards is already flipped
                throw new InvalidOperationException("Invalid card positions.");
            }

            // Flip the cards
            card1.IsFlipped = true;
            card2.IsFlipped = true;

            if (card1.Content == card2.Content)
            {
                // Cards match
                if (playerId == 1)
                {
                    _gameState.Player1Score++;
                }
                else
                {
                    _gameState.Player2Score++;
                }
            }
            else
            {
                // Cards do not match, switch turns
                _gameState.CurrentPlayer = playerId == 1 ? 2 : 1;
            }
        }

        private Card GetCard(int position)
        {
            return _gameState.Cards.FirstOrDefault(c => c.Id == position);
        }

        public bool IsGameEnded()
        {
            return _gameState.Cards.All(c => c.IsFlipped);
        }

        public void ResetGame()
        {
            InitializeGame();
        }
    }
}
