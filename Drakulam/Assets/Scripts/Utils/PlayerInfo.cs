namespace Utils
{
    public struct PlayerInfo
    {
        public enum CharacterClass
        {
            Human,
            Vampire
        }

        public CharacterClass characterClass { get;}

        public PlayerInfo(CharacterClass characterClass_)
        {
            characterClass = characterClass_;
        }
    }
}