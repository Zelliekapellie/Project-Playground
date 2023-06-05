using System.Text.RegularExpressions;

namespace Service_Porcupine.Models
{
    public enum PermissionLevel
    {
        Level1, Level2, Level3
    }

    public class PermissionsM
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public PermissionLevel? Level { get; set; }
    }
}
