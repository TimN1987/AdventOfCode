import fs, { rmSync } from "fs"
import path from "path"

export default class Day10 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day10.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.positions = data
            .split('\n')
            .map(line => line.trim())
            .filter(line => line.length > 0)
            .map(line => line.split(',').map(Number));
    }

    printResults() {
        console.log("Day 10:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
    }

    part2() {
    }
}