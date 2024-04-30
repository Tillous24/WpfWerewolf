using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WpfWerewolf.Presentation_Layer.Presenters;
using Werewolf_Companion.Domain_Model;
using System.Windows;
using WpfWerewolf.Presentation_Layer.Presenters.NightActions;

namespace WpfWerewolf.UnitTests
{
    [TestClass]
    public class GameControllerTests
    {
        private GameController _gameController;
        private Mock<GameSession> _mockGameSession;

        [TestInitialize]
        public void Setup()
        {
            // Mock-Objekt für IGameSession erstellen
            _mockGameSession = new Mock<GameSession>();

            // GameController mit dem Mock-Objekt initialisieren
            _gameController = new GameController();
        }

        [TestMethod]
        public void StartRound_ShouldShowNightfallWindow()
        {
            // Arrange: Verhalten des Mock-Objekts festlegen
            _mockGameSession.Setup(x => x.ActiveParticipants()).Returns(new List<Player>());

            // Act: Methode ausführen, die das Verhalten des Mock-Objekts verwendet
            _gameController.StartRound();

            // Assert: Überprüfen, ob das erwartete Verhalten auftritt
            Assert.IsInstanceOfType(_gameController.CurrentWindow, typeof(Nightfall));
        }

        [TestMethod]
        public void HandleGameFlow_NightActionsPhase_ShouldShowKnightActionWindow()
        {
            // Arrange: Verhalten des Mock-Objekts festlegen
            _mockGameSession.Setup(x => x.ActiveParticipants()).Returns(new List<Player>());
            _gameController.CurrentPhase = "NightActions";

            // Act: Methode ausführen, die das Verhalten des Mock-Objekts verwendet
            _gameController.HandleGameFlow();

            // Assert: Überprüfen, ob das erwartete Verhalten auftritt
            Assert.IsInstanceOfType(_gameController.CurrentWindow, typeof(KnightAction));
        }

        [TestMethod]
        public void TestHandleGameFlow_Sunrise()
        {
            // Arrange: Verhalten des Mock-Objekts festlegen
            _mockGameSession.Setup(x => x.ActiveParticipants()).Returns(new List<Player>());
            _gameController.CurrentPhase = "Sunrise";
            _gameController.CurrentWindow = new Window();

            // Act: Methode ausführen, die das Verhalten des Mock-Objekts verwendet
            _gameController.HandleGameFlow();

            // Assert: Überprüfen, ob das erwartete Verhalten auftritt
            Assert.IsInstanceOfType(_gameController.CurrentWindow, typeof(Sunrise));
        }

        [TestMethod]
        public void TestCheckGameEnded()
        {
            // Arrange: Verhalten des Mock-Objekts festlegen
            List<Role> roles = new List<Role>() { new Werewolf(), new Villager(), new Villager(), new Villager(), new Piper() };
            _mockGameSession.Setup(x => x.SelectedRoles()).Returns(roles);
            _mockGameSession.Setup(x => x.NumParticipants()).Returns(3);

            // Act: Methode ausführen, die das Verhalten des Mock-Objekts verwendet
            bool result = _gameController.CheckGameEnded(true, true, true);

            // Assert: Überprüfen, ob das erwartete Verhalten auftritt
            Assert.IsFalse(result); // Das Spiel sollte nicht enden, wenn alle Spieler verzaubert sind, aber es immer noch Werwölfe und andere Rollen gibt
        }
    }
}
