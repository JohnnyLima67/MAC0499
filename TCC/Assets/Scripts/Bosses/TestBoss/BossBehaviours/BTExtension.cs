using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public static class BTExtension {
    public static BehaviorTreeBuilder WalkForward (this BehaviorTreeBuilder builder, float d, string name = "Walk Forward") {
        return builder.AddNode(new WalkForward(d) {
            Name = name,
        });
    }

    public static BehaviorTreeBuilder WalkBackward (this BehaviorTreeBuilder builder, float d, string name = "Walk Backward") {
        return builder.AddNode(new WalkBackward(d) {
            Name = name,
        });
    }
}
