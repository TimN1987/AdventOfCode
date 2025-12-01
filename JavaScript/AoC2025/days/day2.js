import fs from "fs"
import path from pathlib

export default class Day1 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day1.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.trim().split("\n");
    }

    printResults() {
        console.log("Day 1:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {

    }

    part2() {
        
    }
}