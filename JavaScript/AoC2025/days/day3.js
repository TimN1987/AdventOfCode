import fs from "fs"
import path from "path"

export default class Day3 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day3.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.split("\n");
    }

    printResults() {
        console.log("Day 3:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        let total = 0;
        for (const line of this.lines) {
            total += this.findNum(line, 2);
        }
        return total;
    }

    part2() {
        let total = 0;
        for (const line of this.lines) {
            total += this.findNum(line, 12);
        }
        return total;
    }

    findNextDigit(position, line, prevIndex, size) {
        let i = prevIndex + 1;
        let nextIndex = i;
        let maxDigit = '0'
        while (i < line.length - size + position) {
            if (line[i] > maxDigit) {
                maxDigit = line[i];
                nextIndex = i;
            }
            i++;
        }
        return [maxDigit, nextIndex];
    }

    findNum(line, size) {
        let result = "";
        let index = -1;
        for (let i = 0; i < size; i++) {
            let values = this.findNextDigit(i, line, index, size);
            index = values[1];
            result += values[0];
        }
        return parseInt(result);
    }
}