

interface GameCharacter{

    void processHpEvent(int damage);
    void processMpEvent(int charge);
    int processBattleEvent();
    void processDefenceEvent(int atk, bool phisic);
    void processLevelEvent();
	

}
