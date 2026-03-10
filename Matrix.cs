namespace TourneeFutee
{
    using System;
    using System.Collections.Generic;
    namespace TourneeFutee
    {
        public class Matrix
        {// TODO : ajouter tous les attributs que vous jugerez pertinents 

            private List<List<float>> mat;
            private int nbRows;
            private int nbColums;
            private float defaultValue;

            /* Crée une matrice de dimensions `nbRows` x `nbColums`.
          * Toutes les cases de cette matrice sont remplies avec `defaultValue`.
          * Lève une ArgumentOutOfRangeException si une des dimensions est négative
          */
            public Matrix(int nbRows = 0, int nbColumns = 0, float defaultValue = 0)// TODO : implémenter
            {
                if (nbRows < 0 || nbColumns < 0)
                {
                    throw new ArgumentOutOfRangeException("Les dimensions de la matrice doivent être positives.");
                }
                this.nbRows = nbRows;
                this.nbColums = nbColumns;
                this.defaultValue = defaultValue;
                this.mat = new List<List<float>>();

                for (int i = 0; i < nbRows; i++)
                {
                    List<float> row = new List<float>();
                    for (int j = 0; j < nbColumns; j++)
                    {
                        row.Add(defaultValue);
                    }
                    this.mat.Add(row);
                }
            }

            // Propriété : valeur par défaut utilisée pour remplir les nouvelles cases
            // Lecture seule
            public float DefaultValue
        {
                get { return this.defaultValue; } // TODO : implémenter
                                                  // pas de set
            }

        // Propriété : nombre de lignes
        // Lecture seule
        public int NbRows
        {
                get { return this.nbRows; } // TODO : implémenter
                                            // pas de set
            }

        // Propriété : nombre de colonnes
        // Lecture seule
        public int NbColumns
        {
                get { return this.nbColums; } // TODO : implémenter
                                              // pas de set
            }

        /* Insère une ligne à l'indice `i`. Décale les lignes suivantes vers le bas.
         * Toutes les cases de la nouvelle ligne contiennent DefaultValue.
         * Si `i` = NbRows, insère une ligne en fin de matrice
         * Lève une ArgumentOutOfRangeException si `i` est en dehors des indices valides
         */
        public void AddRow(int i)
        {
                if (i < 0 || i > NbRows)   // TODO : implémenter
                {
                    throw new ArgumentOutOfRangeException("L'indice de la ligne doit être compris entre 0 et le nombre de lignes.");
                }
                List<float> newRow = new List<float>();
                for (int j = 0; j < NbColumns; j++)
                {
                    newRow.Add(DefaultValue);
                }
                mat.Insert(i, newRow);
                nbRows++;
            }

        /* Insère une colonne à l'indice `j`. Décale les colonnes suivantes vers la droite.
         * Toutes les cases de la nouvelle ligne contiennent DefaultValue.
         * Si `j` = NbColums, insère une colonne en fin de matrice
         * Lève une ArgumentOutOfRangeException si `j` est en dehors des indices valides
         */
        public void AddColumn(int j)
        {
                if (j < 0 || j > NbColumns)   // TODO : implémenter
                {
                    throw new ArgumentOutOfRangeException("L'indice de la colonne doit être compris entre 0 et le nombre de colonnes.");
                }
                for (int i = 0; i < NbRows; i++)
                {
                    mat[i].Insert(j, DefaultValue);
                }
                nbColums++;
            }

        // Supprime la ligne à l'indice `i`. Décale les lignes suivantes vers le haut.
        // Lève une ArgumentOutOfRangeException si `i` est en dehors des indices valides
        public void RemoveRow(int i)
        {
                if (i < 0 || i >= NbRows)    // TODO : implémenter
                {
                    throw new ArgumentOutOfRangeException("L'indice de la ligne doit être compris entre 0 et le nombre de lignes - 1.");
                }
                mat.RemoveAt(i);
                nbRows--;
            }

        // Supprime la colonne à l'indice `j`. Décale les colonnes suivantes vers la gauche.
        // Lève une ArgumentOutOfRangeException si `j` est en dehors des indices valides
        public void RemoveColumn(int j)
        {
                if (j < 0 || j >= NbColumns)   // TODO : implémenter 
                {
                    throw new ArgumentOutOfRangeException("L'indice de la colonne doit être compris entre 0 et le nombre de colonnes - 1.");
                }
                for (int i = 0; i < NbRows; i++)
                {
                    mat[i].RemoveAt(j);
                }
                nbColums--;
            }

        // Renvoie la valeur à la ligne `i` et colonne `j`
        // Lève une ArgumentOutOfRangeException si `i` ou `j` est en dehors des indices valides
        public float GetValue(int i, int j)
        {
            // TODO : implémenter
            return 0.0f;
        }

        // Affecte la valeur à la ligne `i` et colonne `j` à `v`
        // Lève une ArgumentOutOfRangeException si `i` ou `j` est en dehors des indices valides
        public void SetValue(int i, int j, float v)
        {
            // TODO : implémenter
        }

        // Affiche la matrice
        public void Print()
        {
            // TODO : implémenter
        }


        // TODO : ajouter toutes les méthodes que vous jugerez pertinentes 

    }


}
