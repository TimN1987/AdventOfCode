import fs, { rmSync } from "fs"
import path from "path"

export default class Day6 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day6.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.split('\n').map(line => line.trimEnd());
        this.lines2 = data.split('\n').map(line => line.replace(/\r$/, ""));

    }

    printResults() {
        console.log("Day 6:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        const data = this.parseData1();
        const rows = data.length;
        const length = data[0].length;
        let result = 0;

        for (let i = 0; i < length; i++) {
            const op = data[rows - 1][i];
            let total = op === '+' ? 0 : 1;
            for (let j = 0; j < rows - 1; j++) {
                if (op === '+') {
                    total += parseInt(data[j][i]);
                } else {
                    total *= parseInt(data[j][i]);
                }
            }
            result += total;
        }
        return result;
    }

    part2() {
        let result = 0;
        let nums = [];
        let op = ' ';

        const rows = this.lines2.length;
        const length = this.lines2[0].length;

        for (let i = 0; i < length; i++) {
            if (this.lines2[rows - 1][i] != ' ') {
                op = this.lines2[rows - 1][i];
            }
            let num = '';
            for (let j = 0; j < rows - 1; j++) {
                if (this.lines2[j][i] != ' ') {
                    num += this.lines2[j][i];
                }
            }
            if (num == '') {
                result += this.evaluate(nums, op);
                op = ' ';
                nums = [];
            } else {
                nums.push(parseInt(num));
            }
        }
        return result + this.evaluate(nums, op);
    }

    parseData1() {
        return this.lines.map(line =>
            line
                .trim()
                .split(/\s+/)
        );
    }

    evaluate(nums, op) {
        let result = op === '+' ? 0 : 1;
        for (const num of nums) {
            if (op === '+') {
                result += num;
            } else {
                result *= num;
            }
        }
        return result;
    }
}