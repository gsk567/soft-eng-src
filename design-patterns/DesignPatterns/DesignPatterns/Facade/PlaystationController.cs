namespace DesignPatterns.Facade;

public class PlaystationController
{
    private readonly ActionButtonsEngine actionButtonsEngine;
    private readonly ArrowsEngine arrowsEngine;
    private readonly JoystickEngine joystickEngine;
    private readonly TriggersEngine triggersEngine;

    public PlaystationController()
    {
        this.actionButtonsEngine = new ActionButtonsEngine();
        this.arrowsEngine = new ArrowsEngine();
        this.joystickEngine = new JoystickEngine();
        this.triggersEngine = new TriggersEngine();
    }
    
    public void Up()
    {
        this.arrowsEngine.Up();
    }
    
    public void Down()
    {
        this.arrowsEngine.Down();
    }

    public void Left()
    {
        this.arrowsEngine.Left();
    }
    
    public void Right()
    {
        this.arrowsEngine.Right();
    }
}