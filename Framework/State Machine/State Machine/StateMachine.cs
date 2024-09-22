using System;
using System.Collections.Generic;

public class StateMachine
{
    private StateNode current;
    private Dictionary<Type, StateNode> nodes = new();
    private HashSet<ITransition> anyTransitions = new();

    public void Update()
    {
        var transition = GetTransition();
        if (transition != null)
            ChangeState(transition.To);

        current.State?.Update();
    }

    public void FixedUpdate()
    {
        current.State?.FixedUpdate();
    }

    public void InitState(IState state)
    {
        current = nodes[state.GetType()];
        current.State?.Enter();
    }

    public void ChangeState(IState state)
    {
        if (state == current.State)
            return;

        var previousState = current.State;
        var nextState = nodes[state.GetType()].State;

        previousState?.Exit();
        nextState?.Enter();
        current = nodes[state.GetType()];
    }

    public ITransition GetTransition()
    {
        foreach (var transition in anyTransitions)
            if (transition.Condition.Evaluate() == true)
                return transition;

        foreach (var transition in current.Transitions)
            if (transition.Condition.Evaluate() == true)
                return transition;

        return null;
    }

    public void AddTransition(IState from, IState to, IPredicate condition)
    {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }

    public void AddAnyTransition(IState to, IPredicate condition)
    {
        anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
    }

    public StateNode GetOrAddNode(IState state)
    {
        var node = nodes.GetValueOrDefault(state.GetType());

        if(node == null)
        {
            node = new StateNode(state);
            nodes.Add(state.GetType(), node);
        }

        return node;
    }
}