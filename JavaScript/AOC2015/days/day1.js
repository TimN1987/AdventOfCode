import fs from "fs"
import path from "path"

export default class Day1 {
    constructor() {
        const filePath = path.resolve("../../Data/2015/day1.txt");
        this.data = fs.readFileSync(filePath, "utf-8");
        this.floor = 0;
        this.basementEntered = false;
        this.basementTime = 1;
    }

    moveLift() {
        for (const d of this.data) {
            if (d === '(') {
                this.floor++;
            } else {
                this.floor--;
            }

            if (!this.basementEntered && this.floor === -1) {
                this.basementEntered = true;
            } else if (!this.basementEntered) {
                this.basementTime++;
            }
        }

        console.log(`The final floor was ${this.floor}, and the basement was entered at ${this.basementTime}.`);
    }
}