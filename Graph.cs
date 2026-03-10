using System;
using System.Collections.Generic;
namespace TourneeFutee
{
    public class Graph
    {

        private List<string> vertexNames;     // TODO : ajouter tous les attributs que vous jugerez pertinents 
        private List<float> vertexValues;
        private Matrix adjacencyMatrix;
        private bool directed;
        private float noEdgeValue;


        // --- Construction du graphe ---

        // Contruit un graphe (`directed`=true => orienté)
        // La valeur `noEdgeValue` est le poids modélisant l'absence d'un arc (0 par défaut)
        public Graph(bool directed, float noEdgeValue = 0)
        {
            this.directed = directed;   // TODO : implémenter
            this.noEdgeValue = noEdgeValue;
            this.vertexNames = new List<string>();
            this.vertexValues = new List<float>();
            this.adjacencyMatrix = new Matrix(0, 0, noEdgeValue);
        }

        // --- Propriétés ---

        // Propriété : ordre du graphe
        // Lecture seule
        public int Order
        {
            get { return vertexNames.Count; }    // TODO : implémenter
                                                 // pas de set
        }

        // Propriété : graphe orienté ou non
        // Lecture seule
        public bool Directed
        {
            get { return directed; }    // TODO : implémenter
                                        // pas de set
        }


        // --- Gestion des sommets ---

        // Ajoute le sommet de nom `name` et de valeur `value` (0 par défaut) dans le graphe
        // Lève une ArgumentException s'il existe déjà un sommet avec le même nom dans le graphe
        public void AddVertex(string name, float value = 0)
        {
            if (vertexNames.Contains(name)) //TODO: implémenter
            {
                throw new ArgumentException($"Le sommet de nom '{name}' existe déjà dans le graphe.");
            }
            vertexNames.Add(name);
            vertexValues.Add(value);
            adjacencyMatrix.AddRow(adjacencyMatrix.NbRows);
            adjacencyMatrix.AddColumn(adjacencyMatrix.NbColumns);
        }


        // Supprime le sommet de nom `name` du graphe (et tous les arcs associés)
        // Lève une ArgumentException si le sommet n'a pas été trouvé dans le graphe
        public void RemoveVertex(string name)
        {
            int index = GetVertexIndex(vertexName);// TODO : implémenter
            vertexNames.RemoveAt(index);
            vertexValues.RemoveAt(index);
            adjacencyMatrix.RemoveRow(index);
            adjacencyMatrix.RemoveColumn(index);
        }

        // Renvoie la valeur du sommet de nom `name`
        // Lève une ArgumentException si le sommet n'a pas été trouvé dans le graphe
        public float GetVertexValue(string name)
        {
            int index = GetVertexIndex(vertexName);// TODO : implémenter
            return vertexValues[index];
        }

        // Affecte la valeur du sommet de nom `name` à `value`
        // Lève une ArgumentException si le sommet n'a pas été trouvé dans le graphe
        public void SetVertexValue(string name, float value)
        {
            int index = GetVertexIndex(vetrtexName);    // TODO : implémenter
            vertexValues[index] = value;
        }


        // Renvoie la liste des noms des voisins du sommet de nom `vertexName`
        // (si ce sommet n'a pas de voisins, la liste sera vide)
        // Lève une ArgumentException si le sommet n'a pas été trouvé dans le graphe
        public List<string> GetNeighbors(string vertexName)
        {
            List<string> neighborNames = new List<string>();

            int index = GetVertexIndex(vertexName);  // TODO : implémenter
            for (int j = 0; j < Order; j++)
            {
                if (adjacencyMatrix[index, j] != noEdgeValue)
                {
                    neighborNames.Add(vertexNames[j]);
                }
            }

            return neighborNames;
        }

        // --- Gestion des arcs ---

        /* Ajoute un arc allant du sommet nommé `sourceName` au sommet nommé `destinationName`, avec le poids `weight` (1 par défaut)
         * Si le graphe n'est pas orienté, ajoute aussi l'arc inverse, avec le même poids
         * Lève une ArgumentException dans les cas suivants :
         * - un des sommets n'a pas été trouvé dans le graphe (source et/ou destination)
         * - il existe déjà un arc avec ces extrémités
         */
        public void AddEdge(string sourceName, string destinationName, float weight = 1)
        {
            int sourceIndex = GetVertexIndex(sourceName);   // TODO : implémenter
            int destinationIndex = GetVertexIndex(destinationName);
            if (adjacencyMatrix[sourceIndex, destinationIndex] != noEdgeValue)
            {
                throw new ArgumentException($"Il existe déjà un arc allant de '{sourceName}' à '{destinationName}'.");
            }
            adjacencyMatrix.SetValue(sourceIndex, destinationIndex, weight);
            if (!directed)
            {
                adjacencyMatrix.SetValue(destinationIndex, sourceIndex, weight);
            }
        }

        /* Supprime l'arc allant du sommet nommé `sourceName` au sommet nommé `destinationName` du graphe
         * Si le graphe n'est pas orienté, supprime aussi l'arc inverse
         * Lève une ArgumentException dans les cas suivants :
         * - un des sommets n'a pas été trouvé dans le graphe (source et/ou destination)
         * - l'arc n'existe pas
         */
        public void RemoveEdge(string sourceName, string destinationName)
        {
            int sourceIndex = GetVertexIndex(sourceName);   // TODO : implémenter
            int destinationIndex = GetVertexIndex(destinationName);
            if (adjacencyMatrix[sourceIndex, destinationIndex] == noEdgeValue)
            {
                throw new ArgumentException($"Il n'existe pas d'arc allant de '{sourceName}' à '{destinationName}'.");
            }
            adjacencyMatrix.SetValue(sourceIndex, destinationIndex, noEdgeValue);
            if (!directed)
            {
                adjacencyMatrix.SetValue(destinationIndex, sourceIndex, noEdgeValue);
            }
        }

        /* Renvoie le poids de l'arc allant du sommet nommé `sourceName` au sommet nommé `destinationName`
         * Si le graphe n'est pas orienté, GetEdgeWeight(A, B) = GetEdgeWeight(B, A) 
         * Lève une ArgumentException dans les cas suivants :
         * - un des sommets n'a pas été trouvé dans le graphe (source et/ou destination)
         * - l'arc n'existe pas
         */
        public float GetEdgeWeight(string sourceName, string destinationName)
        {
            int sourceIndex = GetVertexIndex(sourceName);   // TODO : implémenter
            int destinationIndex = GetVertexIndex(destinationName);
            float weight = adjacencyMatrix.GetValue(sourceIndex, destinationIndex);
            if (weight == noEdgeValue)
            {
                throw new ArgumentException($"Il n'existe pas d'arc allant de '{sourceName}' à '{destinationName}'.");
            }
            return weight;
        }

        /* Affecte le poids l'arc allant du sommet nommé `sourceName` au sommet nommé `destinationName` à `weight` 
         * Si le graphe n'est pas orienté, affecte le même poids à l'arc inverse
         * Lève une ArgumentException si un des sommets n'a pas été trouvé dans le graphe (source et/ou destination)
         */
        public void SetEdgeWeight(string sourceName, string destinationName, float weight)
        {
            int sourceIndex = GetVertexIndex(sourceName);   // TODO : implémenter
            int destinationIndex = GetVertexIndex(destinationName);
            adjacencyMatrix.SetValue(sourceIndex, destinationIndex, weight);
            if (!directed)
            {
                adjacencyMatrix.SetValue(destinationIndex, sourceIndex, weight);
            }
        }

        // TODO : ajouter toutes les méthodes que vous jugerez pertinentes 

        private int GetVertexIndex(string name)
        {
            int index = vertexNames.IndexOf(vertexName);
            if (index == -1)
            {
                throw new ArgumentException($"Le sommet de nom '{name}' n'a pas été trouvé dans le graphe.");
            }
            return index;
        }
    }


}
