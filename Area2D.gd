extends Area2D
var Left = 1

func _physics_process(delta):
	self.position.x -= 1*self.Left
	

func _on_Area2D_body_entered(body):
	self.Left = self.Left * -1
	$AnimatedSprite.flip_h = !$AnimatedSprite.flip_h
