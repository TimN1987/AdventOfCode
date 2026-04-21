import fs from "fs"
import path from "path"

export default class Day3 {
    constructor() {
        const filePath = path.resolve("../../Data/2018/day3.txt");
        const regex = /[0-9]+/g;
        this.data = fs.readFileSync(filePath, "utf-8")
            .split(/\r?\n/)
            .map(line => line.trim())
            .filter(line => line !== "")
            .map(line => {
                const matches = line.match(regex);
                return matches ? matches.map(Number) : [];
        });
        this.grid = new Int32Array(1000000);
        for (const arr of this.data) {
            this.markFabric(arr);
        }
    }

    solve() {
        console.log("Day 3 solutions:");
        this.partOne();
        this.partTwo();
    }

    partOne() {
        let count = 0;
        for (let i = 0; i < this.grid.length; ++i) {
            if (this.grid[i] === -1)
                count++;
        }
        console.log(`There number of overlaps is: ${count}`);
    }

    partTwo() {
        for (const arr of this.data) {
            if (this.checkOverlap(arr)) {
                console.log(`The fabric with no overlap has id ${arr[0]}`);
                return;
            }
        }
    }

    markFabric(arr) {
        for (let i = arr[1]; i < arr[1] + arr[3]; ++i) {
            for (let j = arr[2]; j < arr[2] + arr[4]; ++j) {
                const idx = 1000 * i + j;
                if (this.grid[idx] === 0) {
                    this.grid[idx] = arr[0];
                } else {
                    this.grid[idx] = -1;
                }
            }
        }
    }

    checkOverlap(arr) {
        for (let i = arr[1]; i < arr[1] + arr[3]; ++i) {
            for (let j = arr[2]; j < arr[2] + arr[4]; ++j) {
                const idx = 1000 * i + j;
                if (this.grid[idx] === -1) {
                    return false;
                }
            }
        }
        return true;
    }
}