using System.Linq;
using System.Windows;
using Werewolf_Companion.Domain_Model;
using WpfWerewolf.Domain_Model.Managers;
using WpfWerewolf.Presentation_Layer.Presenters;
using WpfWerewolf.Presentation_Layer.Presenters.NightActions;

public class GameController
{
    private static GameController _instance;
    private GameSession _gameSession;
    private SessionManager _sessionManager;
    private Window _currentWindow;
    private Window _nextWindow;
    private string _currentPhase;
    private bool _allPlayersCharmed;
    private bool _werewolfExist;
    private bool _otherRoleExist;

    private int flowIndex;
    // Singleton instance property
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameController();
            }
            return _instance;
        }
    }

    public GameController()
    {
        // Initialize the GameSession when the controller is created
        _gameSession = new GameSession();
        _sessionManager = new SessionManager(_gameSession);
        
    }
    
    // Method to create a new GameSession
    public GameSession CreateNewGameSession()
    {
        _gameSession = new GameSession();
        return _gameSession;
    }

    // Method to get the current GameSession
    public GameSession CurrentGameSession
    {
        get { return _gameSession; }
        set { _gameSession = value; }
    }

    public SessionManager CurrentSessionManager 
    { 
        get { return _sessionManager; } 
        set { _sessionManager = value; }
    }

    public Window CurrentWindow
    {
        get { return _currentWindow; }
        set { _currentWindow = value; }
    }

    public string CurrentPhase
    {
        get { return _currentPhase; }
        set { _currentPhase = value; }
    }

    // Method to show the next window
    public void ShowNextWindow()
    {
        
        // Show the next window
        _nextWindow.Show();
    }

    public void StartRound() 
    {
        var nightfall = Nightfall.Instance;
        nightfall.Show();
        flowIndex = 0;
    }

    // Method to handle the game flow based on the current phase
    public void HandleGameFlow()
    {
        switch (_currentPhase)
        {
            case "NightActions":
                // Night Actions phase
                ShowNightActionsWindow();
                break;
            case "Sunrise":
                // Sunrise phase
                ShowSunriseWindow();
                break;
            case "Voting":
                // Voting phase
                ShowVotingWindow();
                break;
                // Add more cases for other phases as needed
        }
    }

    // Method to show the Night Actions window
    private void ShowNightActionsWindow()
    {

        bool knightTurn = _gameSession.ActiveParticipants().Any(player => player.assignedRole is Knight && player.isAlive && flowIndex==0);
        if (knightTurn)
        {
            _currentWindow.Hide();
            var knightWindow = KnightAction.Instance;
            _nextWindow = knightWindow;
            flowIndex= 1;
            return;
        }
        
        else if(flowIndex==0){ flowIndex = 1; }

        if (flowIndex==1)
        {
            _currentWindow.Hide();
            var werewolfWindow = WerewolfAction.Instance;
            _nextWindow = werewolfWindow;
            flowIndex= 2;
            return;
        }
        else if(flowIndex==1){ flowIndex=2; }

        bool seerTurn = _gameSession.ActiveParticipants().Any(player => player.assignedRole is Seer && player.isAlive && flowIndex == 2);
        if (seerTurn)
        {
            _currentWindow.Hide();
            var seerWindow =SeerAction.Instance;
            _nextWindow = seerWindow;
            flowIndex= 3;
            return;
        }
        else if (flowIndex == 2) {  flowIndex=3; }

        bool cupidTurn = _gameSession.ActiveParticipants().Any(player => player.assignedRole is Cupid && player.isAlive && player.assignedRole.hasUsedAbility== false && flowIndex == 3);
        if (cupidTurn)
        {
            _currentWindow.Hide();
            var cupidWindow = WerewolfAction.Instance;
            _nextWindow = cupidWindow;
            flowIndex= 4;
            return;
        }
        else if (flowIndex == 3) {  flowIndex=4; }

        bool witchTurn = _gameSession.ActiveParticipants().Any(player => player.assignedRole is Witch && player.isAlive && player.assignedRole.hasUsedAbility== false && flowIndex == 4);
        if (witchTurn)
        {
            _currentWindow.Hide();
            var witchWindow = WitchAction.Instance;
            _nextWindow = witchWindow;
            flowIndex= 5;
            return;
        }
        else if (flowIndex == 4) {  flowIndex=5; }

        bool piperTurn = _gameSession.ActiveParticipants().Any(player => player.assignedRole is Piper && player.isAlive && flowIndex == 5);
        if (piperTurn)
        {
            _currentWindow.Hide();
            var piperWindow = PiperAction.Instance;
            _nextWindow = piperWindow;
            flowIndex= 6;
            return;
        }
        else if (flowIndex == 5) {  flowIndex=6; }
        

        bool thieveTurn = _gameSession.ActiveParticipants().Any(player => player.assignedRole is Thieve && player.isAlive && flowIndex == 6);
        if (thieveTurn)
        {
            _currentWindow.Hide();
            var thieveWindow = ThieveAction.Instance;
            _nextWindow = thieveWindow;
            _currentPhase = "Sunrise";
            return;
        }
        else if (flowIndex==6) { _currentPhase = "Sunrise"; }
    }


    private void ShowSunriseWindow()
    {
        flowIndex= 0;
        CheckGameEnded(_allPlayersCharmed, _werewolfExist, _otherRoleExist);

        foreach (Player player in _gameSession.ActiveParticipants())
        {
            if (!player.isAlive)
            {
                _gameSession.RemoveRole(player.assignedRole);
            }
        }

        // Check win conditions
        if (!_otherRoleExist)
        {
            // Villagers win
            ShowEndGameWindow("Villagers");
        }
        else if (!_werewolfExist)
        {
            // Villagers win
            ShowEndGameWindow("Werewolves");
        }
        else if (_allPlayersCharmed)
        {
            // Werewolves win
            ShowEndGameWindow("Piper");
        }
        else
        {
            StartRound();
        }
    }

    
    private void ShowVotingWindow()
    {
        var votingWindow = Voting.Instance;
        _currentPhase = "NightActions";

    }
    private void ShowEndGameWindow(string winner)
    {
        _currentWindow.Hide();
        var sunrise = new Sunrise();
        sunrise.btnEnd.Content = winner + " Wins";
        
    }

    public bool CheckGameEnded(bool allPlayersCharmed, bool werewolvesExist, bool otherRolesExist)
    {
        // Check if every alive player is charmed
        allPlayersCharmed = _gameSession.ActiveParticipants().All(player => player.isCharmed || !player.isAlive);

        // Check if there are still werewolves in the role list
        werewolvesExist = _gameSession.SelectedRoles().Any(role => role is Werewolf);

        // Check if there are still other roles than werewolves in the role list
        otherRolesExist = _gameSession.SelectedRoles().Any(role => !(role is Werewolf));

        return allPlayersCharmed && werewolvesExist && otherRolesExist;
    }
}