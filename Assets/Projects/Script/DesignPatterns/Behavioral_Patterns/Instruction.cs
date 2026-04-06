enum Instruction : byte
{
    INST_SET_HEALTH = 0x00,
    INST_SET_WISDOM = 0x01,
    INST_SET_AGILITY = 0x02,
    INST_PLAY_SOUND = 0x03,
    INST_SPAWN_PARTICLES = 0x04
}

// Nota: byte = 8 bit = 256 valori possibili. Abbastanza per la maggior parte dei giochi.

public class FireBallSpell
{
    byte[] fireballSpell = new byte[]
{
    (byte)Instruction.INST_SET_HEALTH,
    (byte)Instruction.INST_PLAY_SOUND,
    (byte)Instruction.INST_SPAWN_PARTICLES
};
}

/*
Visivamente:

[0x00] [0x03] [0x04]
  ↓      ↓      ↓
 HEALTH SOUND PARTICLES
*/