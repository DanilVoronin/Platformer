using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Managers
{
    public interface ILevelManager
    {
        public UniTaskVoid NextLevel();
        public UniTaskVoid Menu();
        public UniTaskVoid Restart();

        public event System.Action<string> OnLoadLevel;
    }
}
