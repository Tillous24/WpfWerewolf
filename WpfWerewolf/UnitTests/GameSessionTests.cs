using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data;
using Werewolf_Companion.Domain_Model;

namespace WpfWerewolf.UnitTests
{
    [TestClass]
    public class GameSessionTests
    {
        private GameSession _gameSession;
        private Mock<Role> _mockRole;

        [TestInitialize]
        public void Setup()
        {
            _gameSession = new GameSession();
            _mockRole = new Mock<Role>();
        }

        [TestMethod]
        public void TestAddPlayer()
        {
            // Arrange
            Player player = new Player("John");

            // Act
            _gameSession.AddPlayer(player);

            // Assert
            CollectionAssert.Contains(_gameSession.ActiveParticipants(), player);
        }

        [TestMethod]
        public void TestRemovePlayer()
        {
            // Arrange
            Player player = new Player("John");
            _gameSession.AddPlayer(player);

            // Act
            _gameSession.RemovePlayer(player);

            // Assert
            CollectionAssert.DoesNotContain(_gameSession.ActiveParticipants(), player);
        }

        [TestMethod]
        public void TestNumParticipants()
        {
            // Arrange
            _gameSession.AddPlayer(new Player("John"));
            _gameSession.AddPlayer(new Player("Alice"));

            // Act & Assert
            Assert.AreEqual(2, _gameSession.NumParticipants());
        }

        [TestMethod]
        public void TestAddRole()
        {
            // Arrange
            _mockRole.Setup(x => x.name).Returns("Werewolf");

            // Act
            _gameSession.AddRole(_mockRole.Object);

            // Assert
            List<Role> selectedRoles = _gameSession.SelectedRoles();
            Assert.IsTrue(selectedRoles.Contains(_mockRole.Object));
        }
    }
}
