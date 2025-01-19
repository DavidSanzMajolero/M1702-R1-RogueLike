# 🔮 **Rogue Mage: Dungeons of Magic**

¡Bienvenido a *Rogue Mage: Dungeons of Magic*! Este es un juego 2D top-down estilo roguelike, ambientado en un mundo mágico lleno de mazmorras, enemigos desafiantes y poderes extraordinarios. 

## 🎮 **Características del Juego**

### 🧙‍♂️ **El Protagonista**
Eres un mago aventurero explorando mazmorras repletas de magia y peligro.  
- **Movimiento:** Utiliza `W`, `A`, `S`, `D` para moverte en 8 direcciones.  
- **Cambio de arma:** Cambia entre tus tres armas mágicas usando las teclas `1`, `2` y `3`.  
- **Dash:** Utiliza la tecla `Espacio` para realizar un movimiento rápido hacia una dirección (habilidad que se adquiere en la tienda).  

### 🪄 **Armas del Mago**
Tu arsenal incluye tres poderosas varitas, cada una con un estilo de combate único:  
1. **Varita básica (Cuerpo a cuerpo):** Realiza ataques de corto alcance con clic izquierdo. Ideal para combate cercano.  
2. **Varita mejorada (Largo alcance):** Dispara como un francotirador mágico, perfecta para eliminar enemigos a distancia.  
3. **Lanzaburbujas (Media distancia):** Ataca en ráfagas utilizando partículas que dañan a los enemigos en un área media.  

### 👾 **Tipos de Enemigos**
1. **Enemigo Explosivo:**  
   - Controlado por una máquina de estados.  
   - Detecta al jugador dentro de un rango.  
   - Explota al colisionar inflingiendo mas daño.  
2. **Enemigo Torreta:**  
   - Apunta al jugador y dispara a larga distancia.  
   - *Nota:* Este enemigo dejó de funcionar correctamente al convertirlo en un prefab.  

### 🛒 **Tienda de Pociones**
Durante tu aventura, encontrarás una tienda con tres pociones mágicas que puedes adquirir al colisionar con ellas:  
1. **Poción de vida:** Aumenta y regenera la salud del mago.  
2. **Poción de velocidad:** Incrementa la velocidad de movimiento del personaje.  
3. **Poción de dash:** Desbloquea la habilidad de realizar un movimiento rápido (`Espacio`).  

### 🏰 **Mazmorras Procedurales**
Las salas del juego se generan de forma procedural, ofreciendo una experiencia única en cada partida. Estas salas pueden personalizarse mediante el uso de **Scriptable Objects**, lo que permite a los desarrolladores ajustar fácilmente el diseño y contenido de las mazmorras.  

## 🛠️ **Cómo Jugar**
1. Usa las teclas `W`, `A`, `S`, `D` para explorar las mazmorras.  
2. Enfréntate a los enemigos utilizando tus armas mágicas (`1`, `2`, `3` para cambiar entre ellas).  
3. Compra mejoras en la tienda para sobrevivir más tiempo y explorar nuevas áreas.  
4. ¡Derrota a todos los enemigos y conviértete en el maestro de las mazmorras mágicas!  


¡Esperamos que disfrutes esta experiencia roguelike llena de magia y desafíos!

## 📥 **Descarga y Ejecución**
1. Clona este repositorio:  
   ```bash
   git clone https://github.com/DavidSanzMajolero/M1702-R1-RogueLike
