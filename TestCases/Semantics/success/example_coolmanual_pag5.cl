
class Cons inherits List {
	xcar : Int;
	xcdr : List;
	
	isNil() : Bool { false };
	init(hd : Int, tl : List) : Cons {
		{
		xcar <- hd;
		xcdr <- tl;
		new Cons;
		}
	};
};

class List {
};

class Main {
	main() : Int {
		1
	};
};