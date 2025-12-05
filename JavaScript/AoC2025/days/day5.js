import fs from "fs"
import path from "path"

export default class Day5 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day5.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.lines = data.split('\n').map(line => line.trimEnd());
        const parsedData = this.parseData();
        this.available = parsedData[0];
        this.ranges = parsedData[1];
    }

    printResults() {
        console.log("Day 5:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        let total = 0;
        for (const a of this.available) {
            for (const r of this.ranges) {
                if (a >= r[0] && a <= r[1]) {
                    total++;
                    break;
                }
            }
        }
        return total;
    }

    part2() {
        let total = 0;
        for (const range of this.ranges) {
            total += range[1] - range[0];
        }
        return total;
    }

    parseData() {
        let ranges = [];
        const available = [];
        let isRange = true;
        for (const line of this.lines) {
            if (line === "") {
                isRange = false;
                continue;
            }
            if (isRange) {
                const range = line.split('-');
                ranges.push([Number(range[0]), Number(range[1]) + 1]);
            } else {
                available.push(Number(line));
            }
        }
        ranges.sort((a, b) => a[0] === b[0] ? a[1] - b[1] : a[0] - b[0]);
        ranges = this.mergeRanges(ranges);
        return [available, ranges];
    }

    mergeRanges(ranges) {
        const combinedRanges = [];
        let start = ranges[0][0];
        let end = ranges[0][1];

        for (let i = 1; i < ranges.length; i++) {
            let s = ranges[i][0];
            let e = ranges[i][1];

            if (s >= end) {
                combinedRanges.push([start, end]);
                start = s;
                end = e;
            } else {
                end = e > end ? e : end;
            }
        }
        combinedRanges.push([start, end]);
        return combinedRanges;
    }
}