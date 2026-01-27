import fs from "fs"
import path from "path"

export default class Day2 {
    constructor() {
        const filePath = path.resolve("../../Data/2015/day2.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.dimensions = data
            .trim()
            .split("\n")
            .map(line => {
                return line.split("x").map(Number).sort((a, b) => a - b);
            });
    }

    orderStock() {
        let paper = 0;
        let ribbon = 0;

        for (const [l, h, w] of this.dimensions) {
            paper += 3 * l * h + 2 * h * w + 2 * l * w;
            ribbon += 2 * (l + h) + l * h * w;
        }

        console.log(`The elves required ${paper} square feet of paper and ${ribbon} feet of ribbon.`);
    }
}