public class SpawnWeight
{
    public enum SPAWN_WEIGHT : int {
        ZERO = 0,
        ONE = 5,
        TWO = 15,
        THREE = 30,
    }

    public SPAWN_WEIGHT weight = SPAWN_WEIGHT.ZERO;

    public uint id {get;}

    public SpawnWeight(uint id)
    {
        this.id = id;
    }

    public void toZero()
    {
        weight = SPAWN_WEIGHT.ZERO;
    }

    public static SpawnWeight operator++ (SpawnWeight sw)
    {
        var newWeight = new SpawnWeight(sw.id);
        switch(sw.weight)
        {
            case SPAWN_WEIGHT.ZERO:
                newWeight.weight = SPAWN_WEIGHT.ONE;
                break;
            case SPAWN_WEIGHT.ONE:
                newWeight.weight = SPAWN_WEIGHT.TWO;
                break;
            case SPAWN_WEIGHT.TWO:
            case SPAWN_WEIGHT.THREE:
                newWeight.weight = SPAWN_WEIGHT.THREE;
                break;
        }
        return newWeight;
    }

    public static SpawnWeight operator+ (SpawnWeight sw , int d)
    {
        for (int i = 0; i < d; ++i)
        {
            ++sw;
        }
        return sw;
    }

    public static SpawnWeight operator-- (SpawnWeight sw)
    {
        var newWeight = new SpawnWeight(sw.id);
        switch(sw.weight)
        {
            case SPAWN_WEIGHT.ZERO:
            case SPAWN_WEIGHT.ONE:
                newWeight.weight = SPAWN_WEIGHT.ZERO;
                break;
            case SPAWN_WEIGHT.TWO:
                newWeight.weight = SPAWN_WEIGHT.ONE;
                break;
            case SPAWN_WEIGHT.THREE:
                newWeight.weight = SPAWN_WEIGHT.TWO;
                break;
        }
        return newWeight;
    }

    public static SpawnWeight operator- (SpawnWeight sw, int d)
    {
        for (int i = 0; i < d; ++i)
        {
            --sw;
        }
        return sw;
    }
}
