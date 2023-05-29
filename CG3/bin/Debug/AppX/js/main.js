// Your code here!
var UNITWIDTH = 90; // Width of a cubes in the maze
var UNITHEIGHT = 45; // Height of the cubes in the maze

var camera, scene, renderer;

var totalCubesWide; // How many cubes wide the maze will be
var collidableObjects = []; // An array of collidable objects used later

var mapSize;

var controls;
var controlsEnabled = false;

// HTML elements to be changed
var blocker = document.getElementById('blocker');

// Flags to determine which direction the player is moving
var moveForward = false;
var moveBackward = false;
var moveLeft = false;
var moveRight = false;

var direction;

var SPHERESCALE = 10;

var sphere;

var count_x = 0;
var count_z = 0;

var SPHERECOLLISIONDISTANCE =85

var gameover = false;

var totalCubesWide;
var collidableObjects = [];

var colision = false;

var ground_material;

// Get the pointer lock state
getPointerLock();
init();
animate();

function init() {
    // Create the scene where everything will go
    scene = new THREE.Scene();

    // Add some fog for effects
    scene.fog = new THREE.FogExp2(0x996633, 0.0000015);

    // Set render settings
    renderer = new THREE.WebGLRenderer();
    renderer.setPixelRatio(window.devicePixelRatio);
    renderer.setClearColor(scene.fog.color);
    renderer.setSize(window.innerWidth, window.innerHeight);
    //renderer.setClearColor(new THREE.Color(0xEEEEEE, 1.0));
    renderer.shadowMapEnabled = true;

    // Get the HTML container and connect renderer to it
    var container = document.getElementById('container');
    container.appendChild(renderer.domElement);

    // Set camera position and view details
    camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 1, 3000);
    // position and point the camera to the center of the scene
    camera.position.x =0;
    camera.position.y = 1800;
    camera.position.z =0;

    // Add the camera
    scene.add(camera);

    // add subtle ambient lighting
    var ambientLight = new THREE.AmbientLight(0x0c0c0c);
    scene.add(ambientLight);

    // add spotlight for the shadows
    var spotLight = new THREE.SpotLight(0xffffff); //spotlight branca
    spotLight.position.set(-1500, 1500, -1500);
    spotLight.castShadow = true;
    scene.add(spotLight);

    // Add the walls(cubes) of the maze
    createMazeCubes();

    createPerimWalls();

    createGround();

    CreateSphere();

    controls = new THREE.PointerLockControls(camera);
    scene.add(controls.getObject());

    camera.lookAt(scene.position);

    // Add lights to the scene
    //addLights();

    
    clock = new THREE.Clock();
    detectSphereCollision();
    MoveSphere();
    // Listen for if the window changes sizes and adjust
    window.addEventListener('resize', onWindowResize, false);
}

function createMazeCubes() {

    // Make the shape of the cube that is UNITWIDTH wide/deep, and UNITHEIGHT tall
    var cubeGeo = new THREE.BoxGeometry(UNITWIDTH, UNITHEIGHT, UNITWIDTH);
    // Make the material of the cube and set it to blue
    var cubeMat = new THREE.MeshPhongMaterial({
        color: 0x81cfe0,
    });

    // Combine the geometry and material to make the cube
    var cube = new THREE.Mesh(cubeGeo, cubeMat);

    // Add the cube to the scene
    scene.add(cube);

    // Update the cube's position
    cube.position.y = UNITHEIGHT / 2;
    cube.position.x = 0;
    cube.position.z = -100;
    // rotate the cube by 30 degrees
    cube.rotation.y = degreesToRadians(30);
}

function addLights() {
    var lightOne = new THREE.DirectionalLight(0xffffff);
    lightOne.position.set(1, 1, 1);
    scene.add(lightOne);

    // Add a second light with half the intensity
    var lightTwo = new THREE.DirectionalLight(0xffffff, .5);
    lightTwo.position.set(1, -1, -1);
    scene.add(lightTwo);
}

function onWindowResize() {

    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();

    renderer.setSize(window.innerWidth, window.innerHeight);
}

function animate() {
    render();
    // Keep updating the renderer
    requestAnimationFrame(animate);
    detectSphereCollision();
    AnimateSphere();
}

function render() {
    renderer.render(scene, camera);
}

function degreesToRadians(degrees) {
    return degrees * Math.PI / 180;
}

function radiansToDegrees(radians) {
    return radians * 180 / Math.PI;
}

function createMazeCubes() {
    // Maze wall mapping, assuming even square
    // 1's are cubes, 0's are empty space
    var map = [
        [0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0,],
        [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0,],
        [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0,],
        [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0,],
        [0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0,],
        [1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1,],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0,],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1,],
        [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0,],
        [1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0,],
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,],
        [1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0,],
        [0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0,],
        [0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0,]
    ];

    // wall details
    var cubeGeo = new THREE.BoxGeometry(UNITWIDTH, UNITHEIGHT, UNITWIDTH);
    var cubeMat = new THREE.MeshPhongMaterial({
        color: 0x81cfe0,
    });

    // Keep cubes within boundry walls
    var widthOffset = UNITWIDTH / 2;
    // Put the bottom of the cube at y = 0
    var heightOffset = UNITHEIGHT / 2;

    // See how wide the map is by seeing how long the first array is
    totalCubesWide = map[0].length;

    // Place walls where 1`s are
    for (var i = 0; i < totalCubesWide; i++) {
        for (var j = 0; j < map[i].length; j++) {
            // If a 1 is found, add a cube at the corresponding position
            if (map[i][j]) {
                // Make the cube
                var cube = new THREE.Mesh(cubeGeo, cubeMat);
                // Set the cube position
                cube.position.z = (i - totalCubesWide / 2) * UNITWIDTH + widthOffset;
                cube.position.y = heightOffset;
                cube.position.x = (j - totalCubesWide / 2) * UNITWIDTH + widthOffset;
                // Add the cube
                scene.add(cube);
                cube.castShadow = true;
                // Used later for collision detection
                collidableObjects.push(cube);
                collidable = scene.getObjectByName("collidable");

            }
        }
    }
    // The size of the maze will be how many cubes wide the array is * the width of a cube
    mapSize = totalCubesWide * UNITWIDTH;
}

function createGround() {
    // Create ground geometry and material
    var groundGeo = new THREE.PlaneGeometry(mapSize, mapSize);
    var groundMat = new THREE.MeshLambertMaterial({ color: 0xA0522D });

    var ground = new THREE.Mesh(groundGeo, groundMat);
    ground.position.set(0, 1, 0);
    // Rotate the place to ground level
    ground.rotation.x = degreesToRadians(90);
    ground.receiveShadow = true;

    scene.add(ground);
}

function createPerimWalls() {
    var halfMap = mapSize / 2;  // Half the size of the map
    var sign = 1;               // Used to make an amount positive or negative

    // Loop through twice, making two perimeter walls at a time
    for (var i = 0; i < 2; i++) {
        var perimGeo = new THREE.PlaneGeometry(mapSize, UNITHEIGHT);
        // Make the material double sided
        var perimMat = new THREE.MeshPhongMaterial({ color: 0x464646, side: THREE.DoubleSide });
        // Make two walls
        var perimWallLR = new THREE.Mesh(perimGeo, perimMat);
        var perimWallFB = new THREE.Mesh(perimGeo, perimMat);

        // Create left/right wall
        perimWallLR.position.set(halfMap * sign, UNITHEIGHT / 2, 0);
        perimWallLR.rotation.y = degreesToRadians(90);
        scene.add(perimWallLR);
        // Used later for collision detection
        collidableObjects.push(perimWallLR);
        // Create front/back wall
        perimWallFB.position.set(0, UNITHEIGHT / 2, halfMap * sign);
        perimWallLR.rotation.z = degreesToRadians(180);
        scene.add(perimWallFB);

        // Used later for collision detection
        collidableObjects.push(perimWallFB);

        sign = -1; // Swap to negative value
    }
}

function getPointerLock() {
    document.onclick = function () {
        container.requestPointerLock();
    }
    document.addEventListener('pointerlockchange', lockChange, false);
}


function lockChange() {
    // Turn on controls
    if (document.pointerLockElement === container) {
        // Hide blocker and instructions
        blocker.style.display = "none";
        controls.enabled = true;
        // Turn off the controls
    } else {
        // Display the blocker and instruction
        blocker.style.display = "";
        controls.enabled = false;
    }
}

function CreateSphere() {
    var sphereGeometry = new THREE.SphereGeometry(4, 20, 20);
    var sphereMaterial = new THREE.MeshLambertMaterial({ color: 0x7777ff });
    var sphere = new THREE.Mesh(sphereGeometry, sphereMaterial);
    // Scale the size of the sphere
    sphere.scale.set(SPHERESCALE, SPHERESCALE, SPHERESCALE);
    sphere.rotation.y = degreesToRadians(-90);
    sphere.position.set(800, 45, 800);
    sphere.name = "sphere";
    scene.add(sphere);
    sphere.castShadow = true;

    // Store the sphere
    sphere = scene.getObjectByName("sphere");
}

function MoveSphere() {
    sphere = scene.getObjectByName('sphere');
    // A key has been pressed
    var onKeyDown = function (event) {

        switch (event.keyCode) {

            case 38: //up
            case 87: // w
                moveForward = true;
                direction = 'forward';
                
                break;

            case 37: // left
            case 65: // a
                moveLeft = true;
                direction = 'left';
               
                break;

            case 40: // down
            case 83: // s
                moveBackward = true;
                direction = 'backward';
                
                break;

            case 39: // right
            case 68: // d
                moveRight = true;
                direction = 'right';

                break;
        }

    };

    // A key has been released
    var onKeyUp = function (event) {

        switch (event.keyCode) {

            case 38: // up
            case 87: // w
                moveForward = false;
                direction = 'forward';
                break;

            case 37: // left
            case 65: // a
                moveLeft = false;
                direction = 'left';
                break;

            case 40: // down
            case 83: // s
                moveBackward = false;
                direction = 'backward';
                break;

            case 39: // right
            case 68: // d
                moveRight = false;
                direction = 'right';
                break;
        }
    };

    // Add event listeners for when movement keys are pressed and released
    document.addEventListener('keydown', onKeyDown, false);
    document.addEventListener('keyup', onKeyUp, false);
}

function rayIntersect(ray, distance) {
    var intersects = ray.intersectObjects(collidableObjects);
    for (var i = 0; i < intersects.length; i++) {
        // Check if there's a collision
        if (intersects[i].distance < distance) {
            return true;
        }
    }
    return false;
}

function detectSphereCollision() {

    sphere = scene.getObjectByName('sphere');

    var cubitos; //pontos de colisao
    var posicao = new THREE.Vector3();

    collidableObjects.forEach(function (element, index) {
        cubitos = collidableObjects[index];
        posicao.setFromMatrixPosition(cubitos.matrixWorld);

        if (posicao.distanceTo(sphere.position) <= SPHERECOLLISIONDISTANCE) {
            console.log("hit");
            colision = true;
            caught();

        }
        else
            colision = false;
    });
}


function AnimateSphere() {
    // If no collision and a movement key is being pressed, apply movement velocity
    if (moveForward) {
        if (colision == false) {
            count_z -= 5;
            sphere.position.z = 800 + count_z;
        }
        else {
            caught();
        }
    }
    if (moveBackward) {
        if (colision == false) {
            count_z += 5;
            sphere.position.z = 800 + count_z;
        }
        else {
            caught();
        }
    }
    if (moveLeft) {
        if (colision == false) {
            count_x -= 5;
            sphere.position.x = 800 + count_x;
        }
        else {
            caught();
        }
    }
    if (moveRight) {
        if (colision == false) {
            count_x += 5;
            sphere.position.x = 800 + count_x;
        }
        else {
            caught();
        }
    }

    controls.getObject().translateX(sphere.x);
    controls.getObject().translateZ(sphere.z);
    }


function caught() {
    blocker.style.display = '';
    instructions.innerHTML = "GAME OVER </br></br></br> Press ESC to restart";
    gameOver = true;
    instructions.style.display = '';
}