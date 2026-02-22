// File: DataStructures/BinarySearchTree.cs

using System;

namespace SmartCitySmartCity.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public void Insert(T data)
        {
            _root = InsertRecursive(_root, data);
        }

        private TreeNode<T> InsertRecursive(TreeNode<T> node, T data)
        {
            if (node == null)
                return new TreeNode<T>(data);

            if (data.CompareTo(node.Data) < 0)
                node.Left = InsertRecursive(node.Left, data);
            else
                node.Right = InsertRecursive(node.Right, data);

            return node;
        }

        public void Delete(T data)
        {
            _root = DeleteRecursive(_root, data);
        }

        private TreeNode<T> DeleteRecursive(TreeNode<T> node, T data)
        {
            if (node == null)
                return null;

            if (data.CompareTo(node.Data) < 0)
                node.Left = DeleteRecursive(node.Left, data);
            else if (data.CompareTo(node.Data) > 0)
                node.Right = DeleteRecursive(node.Right, data);
            else
            {
                // Case 1: No child
                if (node.Left == null && node.Right == null)
                    return null;

                // Case 2: One child
                if (node.Left == null)
                    return node.Right;

                if (node.Right == null)
                    return node.Left;

                // Case 3: Two children
                var successor = FindMin(node.Right);
                node.Data = successor.Data;
                node.Right = DeleteRecursive(node.Right, successor.Data);
            }

            return node;
        }

        private TreeNode<T> FindMin(TreeNode<T> node)
        {
            while (node.Left != null)
                node = node.Left;

            return node;
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderRecursive(_root, action);
        }

        private void InOrderRecursive(TreeNode<T> node, Action<T> action)
        {
            if (node == null)
                return;

            InOrderRecursive(node.Left, action);
            action(node.Data);
            InOrderRecursive(node.Right, action);
        }
    }
}
