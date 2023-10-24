using System.Threading.Tasks;

namespace Exmediator
{
    public class Unit
    {
        private Unit()
        {
            
        }
        
        public static Unit Value => new Unit();
        
        public static ValueTask<Unit> AsyncValue => new ValueTask<Unit>(Value);
        
        public static implicit operator Unit((string, object) _) => Value;
        
        public static implicit operator Unit(string _) => Value;
    }
}