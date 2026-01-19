
// Implementing ExamProctor – Online Exam Review System using custom Stack + custom HashMap
// Following SOLID, DRY, KISS, YAGNI, heavy OOP, encapsulation, inheritance, interface + abstract class


// Custom Node for Stack 

class NavigationNode {
    private int questionId;          // The question number/student visited
    protected NavigationNode next;   // Points to previously visited question

    public NavigationNode(int qId) {
        this.questionId = qId;
        this.next = null;
    }

    public int getQuestionId() {
        return questionId;
    }
}


// Custom Simple Stack for tracking navigation 

class NavigationStack {
    private NavigationNode top;

    public NavigationStack() {
        top = null;
    }

    public void push(int questionId) {
        NavigationNode newNode = new NavigationNode(questionId);
        newNode.next = top;
        top = newNode;
        System.out.println("Navigated to question: " + questionId);
    }

    public int pop() {
        if (top == null) {
            System.out.println("Navigation history is empty.");
            return -1;
        }
        int questionId = top.getQuestionId();
        top = top.next;
        return questionId;
    }

    public int peek() {
        if (top == null) {
            System.out.println("No current question (stack empty).");
            return -1;
        }
        return top.getQuestionId();
    }

    public boolean isEmpty() {
        return top == null;
    }

    public void displayNavigationHistory() {
        if (top == null) {
            System.out.println("No navigation history.");
            return;
        }
        System.out.print("Navigation history (most recent first): ");
        NavigationNode current = top;
        while (current != null) {
            System.out.print(current.getQuestionId() + " -> ");
            current = current.next;
        }
        System.out.println("START");
    }
}


// Custom HashMap Entry for QuestionID → Answer

class AnswerEntry {
    private int questionId;
    private String answer;           // Could be "A", "42", "Paris", etc.
    protected AnswerEntry next;      // For separate chaining

    public AnswerEntry(int qId, String ans) {
        this.questionId = qId;
        this.answer = ans;
        this.next = null;
    }

    public int getQuestionId() {
        return questionId;
    }

    public String getAnswer() {
        return answer;
    }

    public void setAnswer(String newAnswer) {
        this.answer = newAnswer;
    }
}


// Custom Simple HashMap (QuestionID → Answer) using separate chaining

class AnswerHashMap {
    private static final int DEFAULT_CAPACITY = 16;
    private AnswerEntry[] table;
    private int size;

    public AnswerHashMap() {
        table = new AnswerEntry[DEFAULT_CAPACITY];
        size = 0;
    }

    private int hash(int questionId) {
        return Math.abs(questionId) % table.length;
    }

    public void put(int questionId, String answer) {
        int index = hash(questionId);
        AnswerEntry entry = table[index];

        // Check if key already exists → update
        while (entry != null) {
            if (entry.getQuestionId() == questionId) {
                entry.setAnswer(answer);
                System.out.println("Updated answer for Q" + questionId + " → " + answer);
                return;
            }
            entry = entry.next;
        }

        // New entry
        AnswerEntry newEntry = new AnswerEntry(questionId, answer);
        newEntry.next = table[index];
        table[index] = newEntry;
        size++;
        System.out.println("Saved answer for Q" + questionId + " → " + answer);
    }

    public String get(int questionId) {
        int index = hash(questionId);
        AnswerEntry entry = table[index];

        while (entry != null) {
            if (entry.getQuestionId() == questionId) {
                return entry.getAnswer();
            }
            entry = entry.next;
        }
        return null;  // Not answered yet
    }

    public boolean containsKey(int questionId) {
        return get(questionId) != null;
    }

    public int getSize() {
        return size;
    }
}


// Interface defining contract for Exam Proctor system

interface ExamProctorInterface {
    void navigateToQuestion(int questionId);
    void goBackToPreviousQuestion();
    void submitAnswer(int questionId, String answer);
    void submitExam();
    int calculateScore();
}


// Abstract Base Class with common functionality

abstract class AbstractExamProctor implements ExamProctorInterface {
    protected NavigationStack navigationHistory;
    protected AnswerHashMap answers;
    protected String studentId;
    protected boolean examSubmitted;

    public AbstractExamProctor(String studentId) {
        this.studentId = studentId;
        this.navigationHistory = new NavigationStack();
        this.answers = new AnswerHashMap();
        this.examSubmitted = false;
    }

    @Override
    public void navigateToQuestion(int questionId) {
        if (examSubmitted) {
            System.out.println("Exam already submitted. Cannot navigate anymore.");
            return;
        }
        navigationHistory.push(questionId);
    }

    @Override
    public void goBackToPreviousQuestion() {
        if (examSubmitted) {
            System.out.println("Exam already submitted.");
            return;
        }
        int previous = navigationHistory.pop();
        if (previous != -1) {
            System.out.println("Went back from Q" + navigationHistory.peek() +
                               " to Q" + previous);
        }
    }

    @Override
    public void submitAnswer(int questionId, String answer) {
        if (examSubmitted) {
            System.out.println("Exam already submitted. Cannot change answers.");
            return;
        }
        answers.put(questionId, answer);
    }

    @Override
    public void submitExam() {
        if (examSubmitted) {
            System.out.println("Exam already submitted.");
            return;
        }
        examSubmitted = true;
        System.out.println("\n=== Exam Submitted by " + studentId + " ===");
        System.out.println("Total questions answered: " + answers.getSize());
        navigationHistory.displayNavigationHistory();
        int score = calculateScore();
        System.out.println("Final Score: " + score + " points");
    }

    // Template method - children must implement actual scoring logic
    @Override
    public abstract int calculateScore();
}


// Concrete Implementation: MCQ Style Exam

class MCQExamProctor extends AbstractExamProctor {

    // Simple correct answers for demonstration (QuestionId → Correct Answer)
    private static final String[] CORRECT_ANSWERS = {
        null, "A", "C", "B", "D", "A"   // index 1 = Q1, etc.
    };

    public MCQExamProctor(String studentId) {
        super(studentId);
    }

    @Override
    public int calculateScore() {
        int score = 0;
        // Very simple scoring: +4 for correct, 0 otherwise (no negative)
        for (int i = 1; i < CORRECT_ANSWERS.length; i++) {
            String studentAns = answers.get(i);
            if (studentAns != null && studentAns.equals(CORRECT_ANSWERS[i])) {
                score += 4;
            }
        }
        return score;
    }
}


// Concrete Implementation: Numerical Answer Exam

class NumericalExamProctor extends AbstractExamProctor {

    // Simple correct numerical answers for demonstration
    private static final double[] CORRECT_NUMERICAL = {
        0, 42.0, 3.14, 100, 9.8, 0.0   // index 1 = Q1, etc.
    };

    public NumericalExamProctor(String studentId) {
        super(studentId);
    }

    @Override
    public int calculateScore() {
        int score = 0;
        for (int i = 1; i < CORRECT_NUMERICAL.length; i++) {
            String studentAns = answers.get(i);
            if (studentAns != null) {
                try {
                    double value = Double.parseDouble(studentAns);
                    if (Math.abs(value - CORRECT_NUMERICAL[i]) < 0.01) {
                        score += 5;
                    }
                } catch (NumberFormatException e) {
                    // Invalid format → 0 points
                }
            }
        }
        return score;
    }
}


// Main Demonstration

public class ExamProctorDemo {
    public static void main(String[] args) {
        java.util.Scanner scanner = new java.util.Scanner(System.in);

        System.out.print("Enter Student ID (default: STU001): ");
        String studentId = scanner.nextLine().trim();
        if (studentId.isEmpty()) studentId = "STU001";

        System.out.print("Exam type (mcq / numerical, default: mcq): ");
        String examType = scanner.nextLine().trim().toLowerCase();
        if (examType.isEmpty()) examType = "mcq";

        AbstractExamProctor proctor;
        if (examType.equals("numerical")) {
            proctor = new NumericalExamProctor(studentId);
        } else {
            proctor = new MCQExamProctor(studentId);
        }

        System.out.println("\n=== Welcome to Online Exam - " + studentId + " ===\n");

        // Sample navigation & answering
        proctor.navigateToQuestion(1);
        proctor.submitAnswer(1, "A");           // MCQ correct / Numerical wrong

        proctor.navigateToQuestion(2);
        proctor.submitAnswer(2, "C");           // MCQ correct

        proctor.navigateToQuestion(3);
        proctor.submitAnswer(3, "B");           // MCQ wrong

        proctor.navigateToQuestion(4);
        proctor.goBackToPreviousQuestion();     // Back to Q3

        proctor.submitAnswer(3, "C");           // Corrected

        proctor.navigateToQuestion(5);
        proctor.submitAnswer(5, "A");           // MCQ correct / Numerical wrong

        System.out.println("\nCurrent question: Q" + proctor.navigationHistory.peek());

        proctor.submitExam();

        scanner.close();
    }
}
