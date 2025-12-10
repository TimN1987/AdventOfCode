import fs, { rmSync } from "fs"
import path from "path"

export default class Day11 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day11.txt");
        const data = fs.readFileSync(filePath, "utf-8");
    }

    printResults() {
        console.log("Day 11:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
    }

    part2() {
    }
}