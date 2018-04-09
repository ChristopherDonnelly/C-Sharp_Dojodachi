class Dojodachi {
 
    constructor() {
        this.StatusType = {
            'neutral': 0,
            'happy': 1,
            'sad': 2,
            'mad': 3,
            'sleepy': 4,
            'sick': 5,
            'dead': 6
        }

        Object.freeze(this.StatusType);

        this.happiness = 20;
        this.fullness = 20;
        this.energy = 50;
        this.meals = 3;
        this.status = this.StatusType.neutral;
    }
  
}