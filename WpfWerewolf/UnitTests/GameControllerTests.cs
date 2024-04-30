using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWerewolf.Presentation_Layer.Presenters.NightActions;
using WpfWerewolf.Presentation_Layer.Presenters;
using Werewolf_Companion.Domain_Model;
using System.Windows;

namespace WpfWerewolf.UnitTests
{
    [TestClass]
    public class GameControllerTests
    {
        private GameController _gameController;

        [TestInitialize]
        public void Setup()
        {
            _gameController = new GameController();
        }

        [TestMethod]
        public void StartRound_ShouldShowNightfallWindow()
        {
            
            _gameController.StartRound();

            
            Assert.IsInstanceOfType(_gameController.CurrentWindow, typeof(Nightfall));
        }

        [TestMethod]
        public void HandleGameFlow_NightActionsPhase_ShouldShowKnightActionWindow()
        {
            // Arrange
            _gameController.CurrentPhase = "NightActions";

            // Act
            _gameController.HandleGameFlow();

            // Assert
            Assert.IsInstanceOfType(_gameController.CurrentWindow, typeof(KnightAction));
        }

        [TestMethod]
        public void TestHandleGameFlow_Sunrise()
        {
            
            GameController gameController = new GameController();
            gameController.CurrentPhase = "Sunrise";
            gameController.CurrentWindow = new Window();

            
            gameController.HandleGameFlow();

            
            // Verify that the next window is shown
            Assert.IsNotNull(gameController.CurrentWindow);
            Assert.IsTrue(gameController.CurrentWindow.GetType() == typeof(Sunrise));
        }

        [TestMethod]
        public void TestCheckGameEnded()
        {
            // Arrange
            GameController gameController = new GameController();
            List<Player> activeParticipants = new List<Player>()
        {
            new Player("Player1"),
            new Player("Player2"),
            new Player("Player3")
        };
            gameController.CurrentGameSession.AddPlayer(new Player("Player1"));
            gameController.CurrentGameSession.AddPlayer(new Player("Player2"));
            gameController.CurrentGameSession.AddPlayer(new Player("Player3"));
            gameController.CurrentGameSession.AddRole(new Werewolf());
            gameController.CurrentGameSession.AddRole(new Villager());
            gameController.CurrentGameSession.AddRole(new Villager());
            gameController.CurrentGameSession.AddRole(new Villager());
            gameController.CurrentGameSession.AddRole(new Piper());

            // Act
            bool result = gameController.CheckGameEnded(true, true, true);

            // Assert
            Assert.IsFalse(result); // Game should not end if all players are charmed but there are still werewolves and other roles
        }


    }
}
