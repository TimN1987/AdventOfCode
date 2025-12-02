import fs from "fs"
import path from "path"

export default class Day2 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day2.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.trim().split(",");
        this.doubleRegex = /^(\d+)\1$/;
        this.multipleRegex = /^(\d+)\1+$/;
    }

    printResults() {
        console.log("Day 2:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        let total = 0;
        for (const line of this.lines) {
            const boundaries = line.split("-");
            const start = parseInt(boundaries[0]);
            const end = parseInt(boundaries[1]);

            for (let i = start; i <= end; i++) {
                if (this.doubleRegex.test(i.toString()))
                    total += i;
            }
        }
        return total;
    }

    part2() {
        let total = 0;
        for (const line of this.lines) {
            const boundaries = line.split("-");
            const start = parseInt(boundaries[0]);
            const end = parseInt(boundaries[1]);

            for (let i = start; i <= end; i++) {
                if (this.multipleRegex.test(i.toString()))
                    total += i;
            }
        }
        return total;
    }
}