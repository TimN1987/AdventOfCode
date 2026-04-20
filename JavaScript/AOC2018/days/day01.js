import fs from "fs"
import path from "path"

export default class Day1 {
    constructor() {
        const filePath = path.resolve("../../Data/2018/day1.txt");
        this.data = fs.readFileSync(filePath, "utf-8")
            .split(/\r?\n/)
            .filter(line => line.trim() != "")
            .map(n => Number(n.trim()));
    }

    solve() {
        console.log("Day one solutions:");
        this.partOne();
        this.partTwo();
    }

    partOne() {
        let frequency = 0;
        for (const d of this.data) {
            frequency += d;
        }
        console.log(`The final frequency is ${frequency}`);
    }

    partTwo() {
        const seen = new Set();
        let frequency = 0, i = 0;
        while (!seen.has(frequency)) {
            seen.add(frequency);
            frequency += this.data[i];
            i = (i + 1) % this.data.length;
        }
        console.log(`The first repeated frequency is ${frequency}`);
    }
}