using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public static class BTExtension {
    public static BehaviorTreeBuilder WalkForward (this BehaviorTreeBuilder builder, float d, float speed, string name = "Walk Forward") {
        return builder.AddNode(new WalkForward(d, speed) {
            Name = name,
        });
    }

    public static BehaviorTreeBuilder WalkBackward (this BehaviorTreeBuilder builder, float d, float speed, string name = "Walk Backward") {
        return builder.AddNode(new WalkBackward(d, speed) {
            Name = name,
        });
    }

    public static BehaviorTreeBuilder TriggerAnimation (this BehaviorTreeBuilder builder, string triggerName, string name = "Trigger Animation") {
        return builder.AddNode(new TriggerAnimation(triggerName) {
            Name = name + " " + triggerName,
        });
    }

    public static BehaviorTreeBuilder Flip (this BehaviorTreeBuilder builder, string name = "Flip") {
        return builder.AddNode(new Flip() {
            Name = name,
        });
    }

	public static BehaviorTreeBuilder Stomp (this BehaviorTreeBuilder builder, GameObject spikePrefab, GameObject spikeUndergroundRefenrece, string name = "Stomp") {
        return builder.AddNode(new Stomp(spikePrefab, spikeUndergroundRefenrece) {
            Name = name,
        });
    }

}
