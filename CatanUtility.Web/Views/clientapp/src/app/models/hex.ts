import { Edge } from './edge';
import { Vertex } from './vertex';

export class Hex {
    edges: Edge[];
    vertices: Vertex[];
    value: string;
    resourceType: string;
    index: number;
}