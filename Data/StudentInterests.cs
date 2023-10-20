namespace SchoolSearch.Data;

public class StudentInterests
{
    private List<string> _PKinterests;
    private List<string> _KGinterests;
    private List<string> _G1interests;
    private List<string> _G2G3interests;
    private List<string> _G4G5interests;
    private List<string> _G6G8interests;
    private List<string> _G9G12interests;
    private Random _random = new Random();
    
    public StudentInterests()
    {
        //Interest lists generated from GPT-4
        _PKinterests = new List<string>() {
    "Listening to short stories and picture books",
    "Coloring and drawing",
    "Building with blocks",
    "Playing with dolls or action figures",
    "Playing with toy cars and trucks",
    "Exploring outdoor areas (like the backyard or a park)",
    "Singing nursery rhymes or simple songs",
    "Baking or cooking with adult supervision",
    "Playing dress-up or pretend play",
    "Watching educational children's shows",
    "Learning about animals",
    "Creating crafts with paper, glue, and scissors",
    "Running and playing outside",
    "Observing and exploring nature",
    "Gardening with adult supervision",
    "Learning about the planets and stars",
    "Collecting objects like leaves, rocks, or shells",
    "Playing with puzzles and simple board games",
    "Going to a local children's museum",
    "Learning to swim with adult supervision",
    "Dancing to music",
    "Visiting the zoo or an aquarium",
    "Playing with Play-Doh or clay",
    "Listening to and making music",
    "Watching and helping with cooking or baking",
    "Feeding and learning about pets",
    "Making and flying paper airplanes",
    "Learning about different shapes and colors",
    "Exploring sensory play (like sand, water, or slime)",
    "Learning simple magic tricks",
    "Going on a picnic or eating outdoors",
    "Making crafts with recycled materials",
    "Exploring with magnet toys",
    "Planting and taking care of a small garden",
    "Learning about safety and first aid",
    "Creating art with sidewalk chalk",
    "Playing simple musical instruments (like tambourines or maracas)",
    "Exploring with a magnifying glass",
    "Participating in simple science experiments",
    "Making simple jewelry or bead crafts",
    "Reading and learning about fairy tales and folk stories",
    "Building forts or playhouses",
    "Learning about the weather",
    "Playing with bubbles",
    "Creating and participating in puppet shows",
    "Exploring different types of technology (e.g., tablets)",
    "Playing in the water (beach, pool, or sprinklers)",
    "Playing with trains and train tracks",
    "Flying kites"
};
        _KGinterests = new List<string>() {
    "Learning to read and exploring beginner books",
    "Drawing and coloring",
    "Learning about animals",
    "Listening to and creating music",
    "Playing with construction toys like LEGO or blocks",
    "Learning about numbers and simple math through games",
    "Making crafts with paper, glue, and scissors",
    "Exploring nature and going on nature walks",
    "Participating in a sports team or class (e.g., soccer, dance)",
    "Watching educational children's shows",
    "Learning to play a simple musical instrument (like a recorder or ukulele)",
    "Making and flying paper airplanes",
    "Collecting things like stickers, rocks, or leaves",
    "Going to a local children's museum",
    "Baking or cooking with adult supervision",
    "Learning about the solar system",
    "Puppet making and puppet shows",
    "Visiting the zoo or an aquarium",
    "Participating in a children's choir",
    "Trying out magic tricks",
    "Exploring geography with maps and globes",
    "Making DIY slime or play dough",
    "Planting and taking care of a small garden",
    "Crafting with recycled materials",
    "Storytelling and creating simple storybooks",
    "Building models (like airplanes or cars)",
    "Participating in simple science experiments",
    "Learning to swim",
    "Learning basic computer skills or coding with kids' platforms",
    "Observing and learning about the weather",
    "Playing board games and card games",
    "Learning about different cultures",
    "Learning about safety and first aid",
    "Studying insects and butterflies",
    "Creating simple animations with kid-friendly apps",
    "Building and creating with clay or Play-Doh",
    "Learning magic tricks",
    "Going on field trips to interesting places",
    "Learning to ride a bike",
    "Learning about dinosaurs",
    "Making jewelry or bead crafts",
    "Learning to take care of a pet",
    "Participating in a book club for kids",
    "Exploring different types of technology (e.g., tablets)",
    "Learning about the environment and recycling",
    "Playing educational computer games",
    "Bird watching and learning about different bird species",
    "Creating simple robots with kids' robotics kits",
    "Exploring different types of art, like pottery or collage making",
    "Learning a second language, like Spanish or French, through interactive games",
    "Creating and performing in a simple play or puppet show"
};
        _G1interests = new List<string>() {
    "Learning to read and exploring beginner books",
    "Drawing and coloring",
    "Learning about animals",
    "Listening to and creating music",
    "Playing with construction toys like LEGO or blocks",
    "Learning about numbers and simple math through games",
    "Making crafts with paper, glue, and scissors",
    "Exploring nature and going on nature walks",
    "Participating in a sports team or class (e.g., soccer, dance)",
    "Watching educational children's shows",
    "Learning to play a simple musical instrument (like a recorder or ukulele)",
    "Making and flying paper airplanes",
    "Collecting things like stickers, rocks, or leaves",
    "Going to a local children's museum",
    "Baking or cooking with adult supervision",
    "Learning about the solar system",
    "Puppet making and puppet shows",
    "Visiting the zoo or an aquarium",
    "Participating in a children's choir",
    "Trying out magic tricks",
    "Exploring geography with maps and globes",
    "Making DIY slime or play dough",
    "Planting and taking care of a small garden",
    "Crafting with recycled materials",
    "Storytelling and creating simple storybooks",
    "Building models (like airplanes or cars)",
    "Participating in simple science experiments",
    "Learning to swim",
    "Learning basic computer skills or coding with kids' platforms",
    "Observing and learning about the weather",
    "Playing board games and card games",
    "Learning about different cultures",
    "Learning about safety and first aid",
    "Studying insects and butterflies",
    "Creating simple animations with kid-friendly apps",
    "Building and creating with clay or Play-Doh",
    "Learning magic tricks",
    "Going on field trips to interesting places",
    "Learning to ride a bike",
    "Learning about dinosaurs",
    "Making jewelry or bead crafts",
    "Learning to take care of a pet",
    "Participating in a book club for kids",
    "Exploring different types of technology (e.g., tablets)",
    "Learning about the environment and recycling",
    "Playing educational computer games",
    "Bird watching and learning about different bird species",
    "Creating simple robots with kids' robotics kits",
    "Exploring different types of art, like pottery or collage making",
    "Learning a second language, like Spanish or French, through interactive games"
};
        _G2G3interests =  new List<string>() {
    "Learning to read and exploring beginner books",
    "Drawing and coloring",
    "Learning about animals",
    "Listening to and creating music",
    "Playing with construction toys like LEGO or blocks",
    "Learning about numbers and simple math through games",
    "Making crafts with paper, glue, and scissors",
    "Exploring nature and going on nature walks",
    "Participating in a sports team or class (e.g., soccer, dance)",
    "Watching educational children's shows",
    "Learning to play a simple musical instrument (like a recorder or ukulele)",
    "Making and flying paper airplanes",
    "Collecting things like stickers, rocks, or leaves",
    "Going to a local children's museum",
    "Baking or cooking with adult supervision",
    "Learning about the solar system",
    "Puppet making and puppet shows",
    "Visiting the zoo or an aquarium",
    "Participating in a children's choir",
    "Trying out magic tricks",
    "Exploring geography with maps and globes",
    "Making DIY slime or play dough",
    "Planting and taking care of a small garden",
    "Crafting with recycled materials",
    "Storytelling and creating simple storybooks",
    "Building models (like airplanes or cars)",
    "Participating in simple science experiments",
    "Learning to swim",
    "Learning basic computer skills or coding with kids' platforms",
    "Observing and learning about the weather",
    "Playing board games and card games",
    "Learning about different cultures",
    "Learning about safety and first aid",
    "Studying insects and butterflies",
    "Creating simple animations with kid-friendly apps",
    "Building and creating with clay or Play-Doh",
    "Learning magic tricks",
    "Going on field trips to interesting places",
    "Learning to ride a bike",
    "Learning about dinosaurs",
    "Making jewelry or bead crafts",
    "Learning to take care of a pet",
    "Participating in a book club for kids",
    "Exploring different types of technology (e.g., tablets)",
    "Learning about the environment and recycling",
    "Playing educational computer games",
    "Bird watching and learning about different bird species",
    "Creating simple robots with kids' robotics kits",
    "Exploring different types of art, like pottery or collage making",
    "Learning a second language, like Spanish or French, through interactive games"
};
        _G4G5interests =  new List<string>() {
    "Reading chapter books",
    "Joining a school sports team (e.g., soccer, basketball)",
    "Participating in a school choir or band",
    "Building models (like airplanes or cars)",
    "Creative writing or storytelling",
    "Drawing or painting",
    "Playing chess or other strategic games",
    "Drama and theatre arts",
    "Studying foreign languages",
    "Starting a collection (stamps, coins, rocks)",
    "Learning magic tricks or juggling",
    "Creating comic books or graphic novels",
    "Making homemade slime or other science experiments",
    "Joining a dance class (ballet, hip hop, jazz)",
    "Baking or simple cooking",
    "Practicing coding and computer programming",
    "Bird watching or studying animals",
    "Gardening or learning about plants",
    "Watching and discussing educational shows",
    "Origami or paper crafts",
    "Exploring the local environment (parks, nature reserves)",
    "Creating DIY crafts or jewelry",
    "Volunteering in the community",
    "Learning about history and culture",
    "Geocaching or treasure hunting",
    "Building with LEGO or other construction toys",
    "Learning a musical instrument",
    "Participating in a book club",
    "Exploring photography",
    "Joining a scouting organization",
    "Creating animations or digital art",
    "Learning about the solar system and space",
    "Participating in student government",
    "Visiting museums or historical sites",
    "Practicing mindfulness or meditation",
    "Performing magic tricks",
    "Learning about different types of technology (e.g., robots, drones)",
    "Creating and flying kites",
    "Participating in school newspaper or yearbook",
    "Learning to ride a bike or improving biking skills",
    "Creating homemade greeting cards or postcards",
    "Learning about and identifying different types of rocks and minerals",
    "Participating in a school science fair",
    "Playing board games and card games",
    "Exploring nature through hiking or camping trips",
    "Learning about environmental conservation",
    "Making and launching homemade rockets",
    "Puppet making and puppet shows",
    "Building and maintaining an aquarium",
    "Creating and maintaining a personal blog or website"
};
        _G6G8interests = new List<string>() {
    "Reading book series (e.g., Harry Potter, Percy Jackson)",
    "Joining a school sports team (e.g., basketball, soccer, swimming)",
    "Participating in a school band or orchestra",
    "Building and painting model kits",
    "Creative writing and blogging",
    "Drawing, painting, or digital art",
    "Playing chess or other strategy board games",
    "Drama and theatre arts",
    "Learning a foreign language",
    "Collecting unique items (e.g., coins, vintage comic books)",
    "Magic tricks and illusion",
    "Creating and illustrating comic books",
    "Performing science experiments at home",
    "Dance class (e.g., hip hop, ballet, contemporary)",
    "Baking and cooking",
    "Coding and game development",
    "Bird watching or nature photography",
    "Gardening and botany",
    "Watching and discussing documentaries",
    "Origami or other paper crafts",
    "Exploring local parks and nature reserves",
    "DIY projects and crafting",
    "Community service and volunteering",
    "Studying history and cultures",
    "Geocaching and orienteering",
    "LEGO building and design",
    "Learning to play a new instrument",
    "Participating in a book club or writing club",
    "Photography",
    "Scouting (e.g., Boy Scouts, Girl Scouts)",
    "Animation and digital art",
    "Studying astronomy and the solar system",
    "Student government",
    "Visiting museums and historical sites",
    "Mindfulness and yoga",
    "Performing magic shows",
    "Exploring technology (e.g., drones, VR)",
    "Kite making and flying",
    "Participating in school newspaper or yearbook",
    "Cycling and bike repair",
    "Creating homemade postcards or greeting cards",
    "Studying geology and collecting rocks and minerals",
    "Participating in a school science fair",
    "Playing strategy board games and card games",
    "Nature exploration and camping",
    "Learning about environmental conservation",
    "Building and launching model rockets",
    "Puppet making and puppet shows",
    "Creating and maintaining a personal blog or website",
    "Learning about and keeping pets",
    "Aquarium keeping and learning about marine life",
    "Robotics and electronics"
};
        _G9G12interests = new List<string>() {
    "Writing and blogging",
    "Joining a debate or public speaking club",
    "Playing sports (e.g., basketball, football, soccer, track, swimming)",
    "Participating in school bands or orchestras",
    "Learning to code and develop software",
    "Volunteering for community service",
    "Reading a wide variety of literature",
    "Participating in school theater productions",
    "Studying foreign languages",
    "Participating in student government",
    "Developing artistic skills (drawing, painting, sculpting)",
    "Starting a small business or entrepreneurial activity",
    "Developing culinary skills",
    "Participating in chess or other strategic games",
    "Engaging in environmental and conservation projects",
    "Participating in robotics club",
    "Exploring career interests through internships or job shadowing",
    "Building and flying drones or RC planes",
    "Making and editing videos or short films",
    "Building computer or electronics from components",
    "Exploring photography",
    "Starting a blog or YouTube channel",
    "Playing musical instruments",
    "Attending concerts and music festivals",
    "Exploring fashion design",
    "Participating in a book club",
    "Travelling and exploring different cultures",
    "Engaging in mindfulness and yoga practices",
    "Joining a dance class",
    "Learning about personal finance and investing",
    "Exploring astronomy and the universe",
    "Collecting antiques or unique items",
    "Learning magic tricks",
    "Building model kits (cars, planes, ships)",
    "Participating in martial arts",
    "Exploring digital art and graphic design",
    "Learning about film history and film making",
    "Exploring DIY projects and crafting",
    "Gardening and botany",
    "Participating in historical reenactments",
    "Exploring interior design",
    "Learning about and caring for pets",
    "Joining a school newspaper or yearbook",
    "Learning to play chess or other strategic games",
    "Exploring various religions and philosophies",
    "Learning about psychology and human behavior",
    "Exploring outdoor activities (hiking, camping, fishing)",
    "Learning about automotive repair",
    "Joining a scouting organization",
    "Exploring paleontology and fossils",
    "Creating animations or video games",
    "Exploring archeology",
    "Geocaching or orienteering",
    "Learning about political science and current events"
};
        
    }

    public List<string> getThreeInterests(string gradelevel)
    {
        List<string> interests = new List<string>();
        List <int> i= new List<int>();
        switch (gradelevel)
        {
            case "Pre-Kindergarten":
                i = threeUniqueInts(_PKinterests.Count);
                interests.Add(_PKinterests[i[0]]);
                interests.Add(_PKinterests[i[1]]);
                interests.Add(_PKinterests[i[2]]);
                break;
            case "Kindergarten":
                i = threeUniqueInts(_KGinterests.Count);
                interests.Add(_KGinterests[i[0]]);
                interests.Add(_KGinterests[i[1]]);
                interests.Add(_KGinterests[i[2]]);
                break;
            case "First Grade":
                i = threeUniqueInts(_G1interests.Count);
                interests.Add(_G1interests[i[0]]);
                interests.Add(_G1interests[i[1]]);
                interests.Add(_G1interests[i[2]]);
                break;
            case "Second Grade":
            case "Third Grade":
                i = threeUniqueInts(_G2G3interests.Count);
                interests.Add(_G2G3interests[i[0]]);
                interests.Add(_G2G3interests[i[1]]);
                interests.Add(_G2G3interests[i[2]]);
                break;
            case "Fourth Grade":
            case "Fifth Grade":
                i = threeUniqueInts(_G4G5interests.Count);
                interests.Add(_G4G5interests[i[0]]);
                interests.Add(_G4G5interests[i[1]]);
                interests.Add(_G4G5interests[i[2]]);
                break;
            case "Sixth Grade":
            case "Seventh Grade":
            case "Eighth Grade":
                i = threeUniqueInts(_G6G8interests.Count);
                interests.Add(_G6G8interests[i[0]]);
                interests.Add(_G6G8interests[i[1]]);
                interests.Add(_G6G8interests[i[2]]);
                break;
            case "Ninth Grade":
            case "Tenth Grade":
            case "Eleventh Grade":
            case "Twelfth Grade":
                i = threeUniqueInts(_G9G12interests.Count);
                interests.Add(_G9G12interests[i[0]]);
                interests.Add(_G9G12interests[i[1]]);
                interests.Add(_G9G12interests[i[2]]);
                break;
            default:
                i = threeUniqueInts(_G9G12interests.Count);
                interests.Add(_G9G12interests[i[0]]);
                interests.Add(_G9G12interests[i[1]]);
                interests.Add(_G9G12interests[i[2]]);
                break;
        }

        return interests;
    }

    private List<int> threeUniqueInts(int maxsize)
    {
        List<int> ints = new List<int>();
        int first = _random.Next(0, maxsize);
        ints.Add(first);
        int second = _random.Next(0, maxsize);
        //If first and second are the same, regenerate until different
        while (second == first)
        {
            second = _random.Next(0, maxsize);
        }
        ints.Add(second);
        int third = _random.Next(0, maxsize);
        //If third is the same as first or second, regenerate until different
        while (third == first || third == second)
        {
            third = _random.Next(0, maxsize);
        }
        ints.Add(third);
        
        return ints;
    }
}