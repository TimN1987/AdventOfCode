import fs from "fs"
import path from "path"

export default class Day3 {
    constructor() {
        const filePath = path.resolve("../../Data/2015/day3.txt");
        this.data = fs.readFileSync(filePath, "utf-8");
        this.visited = new Set();
        this.visited.add("0,0");
        this.roboVisited = new Set();
        this.roboVisited.add("0,0");
        this.position = [0, 0];
        this.santaPosition = [0, 0];
        this.roboPosition = [0, 0];
        this.isRoboTurn = false;
        this.movements = {
            '^': [-1, 0],
            'v': [1, 0],
            '<': [0, -1],
            '>': [0, 1]
        };
    }

    deliver() {
        for (const c of this.data) {
            const [dx, dy] = this.movements[c];
            this.position = [this.position[0] + dx, this.position[1] + dy];
            this.visited.add(`${this.position[0]},${this.position[1]}`);

            if (this.isRoboTurn) {
                this.roboPosition = [this.roboPosition[0] + dx, this.roboPosition[1] + dy];
                this.roboVisited.add(`${this.roboPosition[0]},${this.roboPosition[1]}`);
            } else {
                this.santaPosition = [this.santaPosition[0] + dx, this.santaPosition[1] + dy];
                this.roboVisited.add(`${this.santaPosition[0]},${this.santaPosition[1]}`);
            }
            this.isRoboTurn = !this.isRoboTurn;
        }

        console.log(`Santa normally visits ${this.visited.size} houses. With robo help, he visits ${this.roboVisited.size} houses.`);
    }
}