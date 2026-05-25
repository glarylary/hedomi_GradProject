const DATABASE = {
        cart: [
          {
            id: 1,
            name: "Oversized Cotton Trench",
            size: "M",
            color: "Sand",
            price: 249.0,
            qty: 1,
            image:
              "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?w=200&q=80",
          },
        ],
        discounts: {
          SPRING20: 0.2,
          SAVE10: 0.1,
          SHOPY15: 0.15,
        },
        taxRate: 0.08,
      };
      // State
      let cartItems = [];
      let discountPct = 0;
      /* ── Simulate async DB fetch ── */
      function fetchCart() {
        return new Promise((resolve) => {
          setTimeout(
            () => resolve(JSON.parse(JSON.stringify(DATABASE.cart))),
            700,
          );
        });
      }
      /* ── Initialize ── */
      async function init() {
        cartItems = await fetchCart();
        renderCart();
      }
      /* ── Render all items ── */
      function renderCart() {
        const container = document.getElementById("cart-items-container");
        const empty = document.getElementById("empty-state");
        const contLink = document.getElementById("continue-link");
        const label = document.getElementById("cart-count-label");
        container.innerHTML = "";
        if (cartItems.length === 0) {
          empty.style.display = "block";
          contLink.style.display = "none";
          label.textContent = "Your cart is empty";
          updateSummary();
          return;
        }
        empty.style.display = "none";
        contLink.style.display = "inline-flex";
        const total = cartItems.reduce((s, i) => s + i.qty, 0);
        label.textContent = `You have ${total} item${total !== 1 ? "s" : ""} in your cart`;
        cartItems.forEach((item) => {
          const div = document.createElement("div");
          div.className = "cart-item";
          div.id = `item-${item.id}`;
          div.innerHTML = `
      <img class="item-img" src="${item.image}" alt="${item.name}"
           onerror="this.style.display='none';this.nextElementSibling.style.display='flex'"/>
      <div class="item-img-placeholder" style="display:none"><i class="fa-regular fa-image"></i></div>
      <div class="item-info">
        <p class="item-name">${item.name}</p>
        <p class="item-meta">Size: ${item.size} | Color: ${item.color}</p>
        <div class="qty-control">
          <button class="qty-btn" onclick="changeQty(${item.id}, -1)">−</button>
          <span class="qty-val" id="qty-${item.id}">${item.qty}</span>
          <button class="qty-btn" onclick="changeQty(${item.id}, +1)">+</button>
        </div>
      </div>
      <span class="item-price" id="price-${item.id}">$${(item.price * item.qty).toFixed(2)}</span>
      <button class="delete-btn" onclick="removeItem(${item.id})" title="Remove">
        <i class="fa-regular fa-trash-can"></i>
      </button>
    `;
          container.appendChild(div);
        });
        updateSummary();
        document.getElementById("cart-badge").textContent = total;
      }
      /* ── Change quantity ── */
      function changeQty(id, delta) {
        const item = cartItems.find((i) => i.id === id);
        if (!item) return;
        item.qty = Math.max(1, item.qty + delta);
        document.getElementById(`qty-${id}`).textContent = item.qty;
        document.getElementById(`price-${id}`).textContent =
          `$${(item.price * item.qty).toFixed(2)}`;
        const total = cartItems.reduce((s, i) => s + i.qty, 0);
        document.getElementById("cart-count-label").textContent =
          `You have ${total} item${total !== 1 ? "s" : ""} in your cart`;
        document.getElementById("cart-badge").textContent = total;
        updateSummary();
      }
      /* ── Remove item ── */
      function removeItem(id) {
        const el = document.getElementById(`item-${id}`);
        el.style.transition = "opacity .3s, transform .3s";
        el.style.opacity = "0";
        el.style.transform = "translateX(30px)";
        setTimeout(() => {
          cartItems = cartItems.filter((i) => i.id !== id);
          renderCart();
          showToast("Item removed from cart");
        }, 300);
      }
      /* ── Update Order Summary ── */
      function updateSummary() {
        const subtotal = cartItems.reduce((s, i) => s + i.price * i.qty, 0);
        const discount = subtotal * discountPct;
        const taxable = subtotal - discount;
        const tax = taxable * DATABASE.taxRate;
        const total = taxable + tax;
        document.getElementById("subtotal").textContent =
          `$${subtotal.toFixed(2)}`;
        document.getElementById("tax").textContent = `$${tax.toFixed(2)}`;
        document.getElementById("total").textContent = `$${total.toFixed(2)}`;
        const shipEl = document.getElementById("shipping");
        if (subtotal === 0) {
          shipEl.textContent = "$0.00";
          shipEl.className = "val";
        } else {
          shipEl.textContent = "Free";
          shipEl.className = "val free-ship";
        }
      }
      /* ── Apply Discount ── */
      function applyDiscount() {
        const code = document
          .getElementById("discount-input")
          .value.trim()
          .toUpperCase();
        if (DATABASE.discounts[code]) {
          discountPct = DATABASE.discounts[code];
          updateSummary();
          showToast(
            `✓ Discount applied: ${(discountPct * 100).toFixed(0)}% off!`,
          );
        } else {
          showToast("Invalid discount code. Try SPRING20");
        }
      }
      /* ── Checkout ── */
      function checkout() {
        if (cartItems.length === 0) {
          showToast("Your cart is empty!");
          return;
        }
        showToast("Redirecting to checkout…");
      }
      /* ── Toast ── */
      function showToast(msg) {
        const wrapper = document.getElementById("toast-wrapper");
        const el = document.createElement("div");
        el.className = "toast-msg";
        el.textContent = msg;
        wrapper.appendChild(el);
        setTimeout(() => {
          el.style.transition = "opacity .3s";
          el.style.opacity = "0";
          setTimeout(() => el.remove(), 300);
        }, 2800);
      }
      /* ── Run ── */
      init();