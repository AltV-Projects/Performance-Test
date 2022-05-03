namespace Database.Model
{
    public class User : Base
    {
        public float PosX { get; set; } = 0;
        public float PosY { get; set; } = 0;
        public float PosZ { get; set; } = 72;
        public string Pos { get; set; } = String.Empty;

    }
}
