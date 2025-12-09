import fs, { rmSync } from "fs"
import path from "path"

export default class Day9 {
    constructor() {
        const filePath = path.resolve("../../Data/2025/day9.txt");
        const data = fs.readFileSync(filePath, "utf-8");
        this.positions = data
            .split('\n')
            .map(line => line.trim())
            .filter(line => line.length > 0)
            .map(line => line.split(',').map(Number));
        this.rectangles = this.getOrderedRectangles();

        this.xCoords = this.getOrderedXCoordinates();
        this.yCoords = this.getOrderedYCoordinates();
        this.xMap = Object.fromEntries(this.xCoords.map((x, i) => [x, i]));
        this.yMap = Object.fromEntries(this.yCoords.map((y, i) => [y, i]));
        this.compressed = this.positions.map(([x, y]) => [this.xMap[x], this.yMap[y]]);

        this.edge = this.scanEdge();
    }

    printResults() {
        console.log("Day 9:");
        console.log(`Part 1: ${this.part1()}`);
        console.log(`Part 2: ${this.part2()}`);
    }

    part1() {
        return this.rectangles[0][0];
    }

    part2() {
        for (const rectangle of this.rectangles) {
            const area = rectangle[0];
            const a = this.compressed[rectangle[1]];
            const b = this.compressed[rectangle[2]];

            if (this.checkRectangle(a, b))
                return area;
        }

        return 0;
    }

    findArea(a, b) {
        return (Math.abs(a[0] - b[0]) + 1) * (Math.abs(a[1] - b[1]) + 1);
    }

    getOrderedRectangles() {
        const length = this.positions.length;
        const rectangles = [];
        for (let i = 0; i < length - 1; i++) {
            for (let j = i + 1; j < length; j++) {
                const area = this.findArea(this.positions[i], this.positions[j]);
                rectangles.push([area, i, j]);
            }
        }
        rectangles.sort((a, b) => b[0] - a[0]);
        return rectangles;
    }

    getOrderedXCoordinates() {
        const xCoords = this.positions.map(coord => coord[0]);
        xCoords.sort((a, b) => a - b);
        return xCoords;
    }

    getOrderedYCoordinates() {
        const yCoords = this.positions.map(coord => coord[1]);
        yCoords.sort((a, b) => a - b);
        return yCoords;
    }

    scanEdge() {
        const edge = new Set();
        const coords = this.compressed.slice();
        let prev = coords[0];
        coords.push(prev);
        for (const pos of coords.slice(1)) {
            const x1 = prev[0];
            const y1 = prev[1];
            const x2 = pos[0];
            const y2 = pos[1];

            if (x1 === x2) {
                for (let i = Math.min(y1, y2); i <= Math.max(y1, y2); i++) {
                    edge.add(`${x1},${i}`);
                }
            } else {
                for (let j = Math.min(x1, x2); j <= Math.max(x1, x2); j++) {
                    edge.add(`${j},${y1}`);
                }
            }

            prev = pos;
        }

        return edge;
    }

    checkRectangle(a, b) {
        const x1 = a[0];
        const y1 = a[1];
        const x2 = b[0];
        const y2 = b[1];

        const maxX = Math.max(x1, x2);
        const minX = Math.min(x1, x2);
        const maxY = Math.max(y1, y2);
        const minY = Math.min(y1, y2);

        for (let x = minX + 1; x < maxX; x++) {
            if (this.edge.has(`${x},${minY + 1}`) || this.edge.has(`${x},${maxY - 1}`))
                return false;
        }

        for (let y = minY + 1; y < maxY; y++) {
            if (this.edge.has(`${minX + 1},${y}`) || this.edge.has(`${maxX - 1},${y}`))
                return false;
        }

        return true;
    }
}