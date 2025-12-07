import fs, { rmSync } from "fs"
import path from "path"

export default class Day7 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day7.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.split('\n').map(line => line.trimEnd().split(''));
        this.grid = data.split('\n').map(line => line.trimEnd().split('').map(c => c === 'S' ? 1 : 0));
        this.runBeam();
    }

    printResults() {
        console.log("Day 7:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        return this.lines.flat().filter(c => c === 'X').length;
    }

    part2() {
        return this.grid[this.grid.length - 1].reduce((total, n) => total + n, 0);
    }

    runBeam() {
        const height = this.lines.length;
        const width = this.lines[0].length;

        for (let i = 1; i < height; i++) {
            for (let j = 0; j < width; j++) {
                if (this.lines[i][j] === '.') {
                    this.grid[i][j] += this.grid[i - 1][j];
                }
                if (this.lines[i][j] === '^' && this.grid[i - 1][j] > 0) {
                    this.lines[i][j] = 'X';
                }
            }
            for (let j = 0; j < width; j++) {
                if (this.lines[i][j] === '^' || this.lines[i][j] === 'X') {
                    if (j > 0) {
                        this.grid[i][j - 1] += this.grid[i - 1][j];
                    }
                    if (j < width - 1) {
                        this.grid[i][j + 1] += this.grid[i - 1][j];
                    }
                }
            }
        }
    }
}