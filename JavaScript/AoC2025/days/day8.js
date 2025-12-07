import fs, { rmSync } from "fs"
import path from "path"

export default class Day7 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day8.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.split('\n').map(line => line.trimEnd());
    }

    printResults() {
        console.log("Day 8:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
    }

    part2() {
    }
}